using HR.BLL.Services.AspNetUserServ;
using HR.BLL.Services.DepartmentServ;
using HR.BLL.Services.TaskServ;
using HR.DAL.GenericRepository;
using HR.DAL.Repository.AspNetUserRepo;
using HR.DAL.Repository.DepartmentRepo;
using HR.DAL.Repository.TaskRepo;
using Sahab.Enterprise.HR.Controllers;
using Sahab.Enterprise.HR.Managers.UploadManager;
using System;

using Unity;
using Unity.Injection;

namespace Sahab.Enterprise.HR
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();


            // inject AccountController  

            container.RegisterType<AccountController>(new InjectionConstructor(typeof(IAspNetUserService),
                typeof(IDepartmentService))); 
            container.RegisterType<ManageController>(new InjectionConstructor());

            // Register Unit of Work 
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            // Register All Repos
            container.RegisterType<IAspNetUserRepository, AspNetUserRepository>();
            container.RegisterType<ITaskRepository, TaskRepository>();
            container.RegisterType<IDepartmentRepository, DepartmentRepository>();

             
            // Register All Services
            container.RegisterType<IAspNetUserService, AspNetUserService>();
            container.RegisterType<ITaskService, TaskService>();
            container.RegisterType<IDepartmentService, DepartmentService>();

            // Register All Managers 
            container.RegisterType<IUploadManager, UploadManager>();
        }
    }
}