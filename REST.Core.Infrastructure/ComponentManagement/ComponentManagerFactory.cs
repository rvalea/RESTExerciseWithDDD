using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Core.Infrastructure.ComponentManagement
{
    public class ComponentManagerFactory
    {
        #region Fields
        private static IComponentManager _componentManager;
        #endregion

        #region Methods
        public static void InitializeComponentManagerFactory(IComponentManager componentManager)
        {
            _componentManager = componentManager;
        }

        public static IComponentManager GetComponentManager()
        {
            return _componentManager;
        }
        #endregion
    }
}