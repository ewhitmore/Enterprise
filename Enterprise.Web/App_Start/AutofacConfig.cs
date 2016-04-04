using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Enterprise.Persistence;
using Enterprise.Persistence.Dao;
using Enterprise.Persistence.Dao.Implementation;
using Enterprise.Web.Services;
using NHibernate;

namespace Enterprise.Web
{
    public static class AutofacConfig
    {
        public static IContainer Container { get; set; }

        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            // Register Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            // NHibernate
            builder.RegisterInstance(HibernateConfig.InitHibernate("Web"));



            // Either use a session in view model or per instance depending on the context.
            if (HttpContext.Current != null)
            {
                // Indicates a web based implementation
                builder.Register(s => s.Resolve<ISessionFactory>().OpenSession()).InstancePerRequest();

            }
            else
            {
                // Indicates unit test (or other non-web based implementation)
                builder.Register(s => s.Resolve<ISessionFactory>().OpenSession());
            }

            builder.RegisterGeneric(typeof(Repository<,>))
                .As(typeof(IRepository<,>))
                .PropertiesAutowired()
                .InstancePerRequest();

            // Services
            AddServices(builder);
            AddTypes(builder);

            // Set the dependency resolver to be Autofac.
            Container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);

        }

        private static void AddTypes(ContainerBuilder builder)
        {
            builder.RegisterType<TeacherDao>().As<ITeacherDao>().PropertiesAutowired();
            builder.RegisterType<StudentDao>().As<IStudentDao>().PropertiesAutowired();
        }

        private static void AddServices(ContainerBuilder builder)
        {
            var serviceAssembly = Assembly.GetAssembly(typeof(TeacherService));

            builder.RegisterAssemblyTypes(serviceAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerRequest();
        }
    }
}