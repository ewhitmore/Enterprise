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


        //SessionContext = "call";
        //SessionContext = "thread_static";
        //SessionContext = "web";

        public static ISessionFactory CreateSessionFactory(string context)
        {
            var sessionFactory = Fluently.Configure()
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
                .ExposeConfiguration(cfg => cfg.SetProperty("current_session_context_class", context))
                .ExposeConfiguration(cfg => cfg.SetProperty("adonet.batch_size", "100"))
                .BuildConfiguration().BuildSessionFactory();

            SessionFactory = sessionFactory;

            return sessionFactory;
        }

        //public static ISessionFactory CreateSessionFactory(string context, string test)
        //{
        //    var sessionFactory = Fluently.Configure()
        //        .Database(MsSqlConfiguration
        //            .MsSql2012
        //            .ConnectionString(c => c.FromConnectionStringWithKey("SampleDatabase")
        //            )
        //        .ShowSql()
        //        // Turn this on for production only
        //        //.UseReflectionOptimizer
        //        )
        //        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StudentMap>())
        //        //.Mappings(m => m.FluentMappings.Add<LogMap>())

        //        // Comment out CreateSchema to keep nhibernate from removing the data each time.
        //        .ExposeConfiguration(SchemaSelector)
        //        //.ExposeConfiguration(cfg => cfg.SetInterceptor(new SqlStatementInterceptor()))
        //        .ExposeConfiguration(cfg => cfg.SetProperty("current_session_context_class", SessionContext))
        //        .ExposeConfiguration(cfg => cfg.SetProperty("adonet.batch_size", "100"))
        //        .BuildConfiguration().BuildSessionFactory();

        //    return sessionFactory;
        //}


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
