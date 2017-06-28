using System;
using System.Collections.Generic;
using REST.Core.Infrastructure.ComponentManagement;
using REST.Core.Business;
using REST.Core.Data;
using REST.Core.Application;

namespace REST.Core.Configuration
{
    public static class ModuleConfigurator
    {
        #region Methods
        public static void Initialize()
        {

            IComponentManager componentManager = new UnityComponentManager();
            ComponentManagerFactory.InitializeComponentManagerFactory(componentManager);

            RegisterComponents(componentManager);
        }

        private static void RegisterComponents(IComponentManager componentManager)
        {
            RegisterRepositories(componentManager);

            RegisterInfrastructure(componentManager);

            RegisterApplicationServices(componentManager);
        }

        private static void RegisterRepositories(IComponentManager componentManager)
        {
            componentManager.RegisterComponent<IUserRepository, UserRepository>();
        }

        private static void RegisterInfrastructure(IComponentManager componentManager)
        {
            // N/A
        }

        private static void RegisterApplicationServices(IComponentManager componentManager)
        {
            componentManager.RegisterComponent<IUserService, UserService>();
        }
        #endregion
    }
}
