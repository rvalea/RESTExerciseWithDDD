using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;

namespace REST.Core.Infrastructure.ComponentManagement
{
    public interface IComponentManager
    {
        TComponent GetInstance<TComponent>();

        object GetInstance(Type componentType);

        IEnumerable<TComponent> GetAllInstances<TComponent>();

        IEnumerable<object> GetAllInstances(Type componentType);

        /// <summary>
        /// Gets all registered types for testing purposes
        /// </summary>
        /// <returns></returns>
        IEnumerable<Type> Registrations();

        void RegisterComponent<TContractType, TConcreteType>();

        /// <summary>
        /// Register components with factories
        /// </summary>
        /// <typeparam name="TContractType"></typeparam>
        /// <param name="action"></param>
        void RegisterComponent<TContractType>(Func<TContractType> action);

        /// <summary>
        /// Register compoonent with designator (for multiple injection purposes)
        /// </summary>
        /// <typeparam name="TContractType"></typeparam>
        /// <typeparam name="TConcreteType"></typeparam>
        /// <param name="designator">should be unique in scope of multiple injection</param>
        void RegisterComponentWithDesignator<TContractType, TConcreteType>(string designator) where TConcreteType : TContractType;

        /// <summary>
        /// Register component with defining resolution strategy (a life time of objects).
        /// </summary>
        /// <typeparam name="TContractType"></typeparam>
        /// <typeparam name="TConcreteType"></typeparam>
        /// <param name="resolutionStrategy"></param>
        void RegisterComponent<TContractType, TConcreteType>(ResolutionStrategyEnum resolutionStrategy);
    }
}