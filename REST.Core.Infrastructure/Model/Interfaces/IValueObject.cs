using System.Collections.Generic;
using System.ComponentModel;

namespace REST.Core.Infrastructure.Model
{
    public interface IValueObject
    {
        IList<ValidationRule> GetBrokenRules();
    }
}