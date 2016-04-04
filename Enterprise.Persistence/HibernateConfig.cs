using System.Configuration;
using System.Diagnostics;
using Enterprise.Persistence.Dao.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Configuration = NHibernate.Cfg.Configuration;

namespace Enterprise.Persistence
{
    public class HibernateConfig
    {
        public static ISessionFactory SessionFactory { get; private set; }
        public static string SessionContext { get; set; }

        //SessionContext = "call";
        //SessionContext = "thread_static";
        //SessionContext = "web";

        /// <summary>
        ///     Initalize Hibernate Factory
        /// </summary>
        /// <param name="context">Must be call, web or thread_static</param>
        public static ISessionFactory InitHibernate(string context)
        {
            SessionContext = context;

            Debug.WriteLine("Configuring NHibernate...");
            Debug.WriteLine("Set Schema:" + ConfigurationManager.AppSettings["Schema"]);

            var sessionFactory = CreateSessionFactory();
            SessionFactory = sessionFactory;

            Debug.WriteLine("Created NHibernate SessionFactories!");

            return SessionFactory;
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration
                    .MsSql2012
                    .ConnectionString(c => c.FromConnectionStringWithKey("SampleDatabase")
                    )
                .ShowSql()
                // Turn this on for production only
                //.UseReflectionOptimizer
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StudentMap>())
                //.Mappings(m => m.FluentMappings.Add<LogMap>())

                // Comment out CreateSchema to keep nhibernate from removing the data each time.
                .ExposeConfiguration(SchemaSelector)
                //.ExposeConfiguration(cfg => cfg.SetInterceptor(new SqlStatementInterceptor()))
                .ExposeConfiguration(cfg => cfg.SetProperty("current_session_context_class", SessionContext))
                .ExposeConfiguration(cfg => cfg.SetProperty("adonet.batch_size", "100"))
                .BuildConfiguration().BuildSessionFactory();
        }

        private static void SchemaSelector(Configuration cfg)
        {
            switch (ConfigurationManager.AppSettings["Schema"])
            {
                case "CREATE":
                    var schemaExport = new SchemaExport(cfg);
                    schemaExport.Drop(false, true);
                    schemaExport.Create(false, true);
                    break;
                case "UPDATE":
                    var schemaUpdate = new SchemaUpdate(cfg);
                    schemaUpdate.Execute(false, true);
                    break;
                default:
                    var schemaValidator = new SchemaValidator(cfg);
                    schemaValidator.Validate();
                    break;
            }
        }

        internal static void Dispose()
        {
            SessionFactory.Dispose();
        }
    }
}
