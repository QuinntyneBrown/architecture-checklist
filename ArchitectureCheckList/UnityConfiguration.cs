using ArchitectureCheckList.Configuration;
using ArchitectureCheckList.Data;
using ArchitectureCheckList.Services;
using ArchitectureCheckList.Utilities;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace ArchitectureCheckList
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer().AddNewExtension<Interception>();
            container.RegisterType<IDbContext, DataContext>();
            container.RegisterType<IUow, Uow>();
            container.RegisterType<IRepositoryProvider, RepositoryProvider>();
            container.RegisterType<IIdentityService, IdentityService>();
            container.RegisterType<ILoggerFactory, LoggerFactory>();
            container.RegisterType<ICacheProvider, CacheProvider>();
            container.RegisterType<IEncryptionService, EncryptionService>();
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<ICheckListService, CheckListService>();
            container.RegisterType<ICheckListItemService, CheckListItemService>();
            container.RegisterType<IProjectService, ProjectService>();
            container.RegisterType<IProjectMemberService, ProjectMemberService>();
            container.RegisterInstance(AuthConfiguration.LazyConfig);            
            return container;
        }
    }
}
