using System;
using System.Globalization;
using REST.Core.Infrastructure.Model;

namespace REST.Core.Infrastructure.Helpers
{
    public static class EnsureThat
    {
        public static void EntityIsValid(IEntity entity)
        {
            var brokenRules = entity.GetBrokenRules();

            if (brokenRules.Count > 0)
            {
                throw new EntityValidationException("Invalid Entity",
                                                    entity.GetType().Name,
                                                    brokenRules);
            }
        }

        public static void EntityIsValid(IValueObject valueObject)
        {
            var brokenRules = valueObject.GetBrokenRules();

            if (brokenRules.Count > 0)
            {
                throw new EntityValidationException("Invalid Entity",
                                                    valueObject.GetType().Name,
                                                    brokenRules);
            }
        }
    }

}
