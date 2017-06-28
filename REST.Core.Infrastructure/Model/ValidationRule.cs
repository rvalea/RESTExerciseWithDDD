using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Core.Infrastructure.Model
{
    public class ValidationRule
    {
        #region Properties
        public string PropertyName { get; protected set; }

        public string Rule { get; protected set; }
        #endregion

        #region Constructor
        public ValidationRule(string propertyName, string rule)
        {
            this.PropertyName = propertyName;
            this.Rule = rule;
        }
        #endregion
    }
}