using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<DbLogger>().As<ILogger>();
            builder.RegisterType<TestClass>().As<ITest>();
            builder.RegisterType<TestClass2>().As<ITest2>();
            builder.RegisterType<TestClass3>().As<ITest3>();
            builder.RegisterType<TestClass4>().As<ITest4>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
