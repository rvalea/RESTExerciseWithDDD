using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace REST.Core.Infrastructure.ComponentManagement
{
    public class UnityComponentManager : IComponentManager
    {
        #region Fields
        private static IUnityContainer _container = new UnityContainer();
        private bool useStrategies = false;
        #endregion

        #region Methods
        public TComponent GetInstance<TComponent>()
        {
            try
            {
                return (TComponent)_container.Resolve<TComponent>();
            }
            catch
            {
                return default(TComponent);
            }
        }

        public object GetInstance(Type componentType)
        {
            try
            {
                return _container.Resolve(componentType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<TComponent> GetAllInstances<TComponent>()
        {
            try
            {
                return (IEnumerable<TComponent>)_container.ResolveAll<TComponent>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<Type> Registrations()
        {
            return _container.Registrations.Select(x => x.RegisteredType);
        }

        public IEnumerable<object> GetAllInstances(Type componentType)
        {
            try
            {
                return (IEnumerable<object>)_container.ResolveAll(componentType);
            }
            catch
            {
                return null;
            }
        }

        public void RegisterComponent<TContractType, TConcreteType>()
        {
            _container.RegisterType(typeof(TContractType), typeof(TConcreteType));
        }

        public void RegisterComponent<TContractType, TConcreteType>(ResolutionStrategyEnum resolutionStrategy)
        {
            if (useStrategies) // a global swith to turn on / off strategies
            {
                if (resolutionStrategy == ResolutionStrategyEnum.DefaultAlwaysNewInstance)
                {
                    RegisterComponent<TContractType, TConcreteType>();
                }
                else
                {
                    var lifetimeManager = GetLifetimeManager(resolutionStrategy);
                    _container.RegisterType(typeof(TContractType), typeof(TConcreteType), lifetimeManager);
                }
            }
            else
            {
                RegisterComponent<TContractType, TConcreteType>();
            }
        }

        public void RegisterComponent<TContractType>(Func<TContractType> action)
        {
            _container.RegisterInstance(action());
        }

        private LifetimeManager GetLifetimeManager(ResolutionStrategyEnum resolutionStrategy)
        {
            LifetimeManager lifetimeManager;
            if (resolutionStrategy == ResolutionStrategyEnum.DefaultAlwaysNewInstance ||
                resolutionStrategy == ResolutionStrategyEnum.AlwaysNewInstance)
            {
                lifetimeManager = new TransientLifetimeManager();
            }
            else if (resolutionStrategy == ResolutionStrategyEnum.SingletonRepository)
            {
                lifetimeManager = new ContainerControlledLifetimeManager();
            }
            else // default
            {
                lifetimeManager = new TransientLifetimeManager();
            }

            return lifetimeManager;
        }

        public void RegisterComponentWithDesignator<TContractType, TConcreteType>(string designator) where TConcreteType : TContractType
        {
            _container.RegisterType<TContractType, TConcreteType>(designator);
        }
        #endregion
    }
}
