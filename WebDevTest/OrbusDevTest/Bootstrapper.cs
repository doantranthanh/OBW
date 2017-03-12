using System.Web.Mvc;
using Microsoft.Practices.Unity;
using OrbusDevTest.DataAccess;
using OrbusDevTest.DataAccess.Category;
using OrbusDevTest.DataAccess.Codes;
using OrbusDevTest.DataAccess.OAService;
using OrbusDevTest.DataAccess.Repository.Category;
using OrbusDevTest.DataAccess.Repository.Product;
using Unity.Mvc4;

namespace OrbusDevTest
{
  public static class Bootstrapper
  {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IWebServiceEndpointManager, WebServiceEndpointManager>();
            container.RegisterType<IOAServiceAgent, OAServiceAgent>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            return container;
        }

    }
}