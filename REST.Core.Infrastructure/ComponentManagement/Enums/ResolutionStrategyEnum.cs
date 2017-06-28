using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Core.Infrastructure.ComponentManagement
{
    public enum ResolutionStrategyEnum
    {
        /// <summary>
        /// Not defined any strategy, by default return new instance.
        /// </summary>
        DefaultAlwaysNewInstance,
        /// <summary>
        /// Strategy for stateless repositories.
        /// </summary>
        SingletonRepository,
        /// <summary>
        /// Defined that type has to be resolved always as new instance.
        /// </summary>
        /// <remarks>Usefull for object with internal state.</remarks>
        AlwaysNewInstance
    }
}
