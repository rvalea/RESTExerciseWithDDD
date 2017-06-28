using System;

namespace REST.Core.Infrastructure.Model
{
    public class BusinessRule : ValidationRule
    {
        #region Constructor
        public BusinessRule(string propertyName, string rule)
            : base(propertyName, rule)
        {
        }
        #endregion
    }
}
