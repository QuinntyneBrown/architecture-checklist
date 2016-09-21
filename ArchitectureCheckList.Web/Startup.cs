using Owin;
using System.Web.Http;
using Microsoft.Owin;
using Unity.WebApi;

[assembly: OwinStartup(typeof(ArchitectureCheckList.Web.Startup))]

namespace ArchitectureCheckList.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            GlobalConfiguration.Configure(config =>
            {
                config.DependencyResolver = new UnityDependencyResolver(UnityConfiguration.GetContainer());
                ArchitectureCheckList.ApiConfiguration.Install(config, app);
            });
        }
    }
}
