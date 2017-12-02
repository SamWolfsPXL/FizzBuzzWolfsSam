using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using FizzBuzz.Web.Models;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;

namespace FizzBuzz.Web
{
    public class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            RegisterApiDependencies();
        }

        private static void RegisterApiDependencies()
        {
            //TODO: setup dependency injection with Simple Injector 
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<IFizzBuzzService, FizzBuzzService>(Lifestyle.Singleton);
            container.Register<IFizzBuzzValidator, FizzBuzzValidator>(Lifestyle.Singleton);

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}