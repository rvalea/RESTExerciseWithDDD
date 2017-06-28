using System;
using System.Collections.Generic;
using System.Linq;

namespace REST.Core.Infrastructure.Model
{
    public class EntityValidationException : Exception
    {
        #region Fields
        private readonly string _entityName;
        private readonly IList<ValidationRule> _brokenRules;
        #endregion

        #region Properties
        public string EntityName
        {
            get
            {
                return _entityName;
            }
        }

        public IEnumerable<ValidationRule> BrokenRules
        {
            get
            {
                return _brokenRules;
            }
        }
        #endregion

        #region Constructors
        public EntityValidationException(string message, string entityName, IList<ValidationRule> brokenRules)
            : base(string.Format("{0}: {1}", message, string.Join(",", brokenRules.Select(a => a.Rule))))
        {
            _entityName = entityName;
            _brokenRules = brokenRules;
        }
        #endregion

        #region Override
        public override string Message
        {
            get { return GetMessage(base.Message, this); }
        }

        public override string StackTrace
        {
            get { return GetStackTrace(base.StackTrace, this); }
        }

        private string GetMessage(string message, Exception exception)
        {
            if (exception != null && exception.InnerException != null)
            {
                message += string.Format(" - {0}", exception.InnerException.Message);

                return GetMessage(message, exception.InnerException);
            }

            return message;
        }

        private string GetStackTrace(string stackTrace, Exception exception)
        {
            if (exception != null && exception.InnerException != null)
            {
                stackTrace += string.Format("{0}{1}", Environment.NewLine, exception.InnerException.StackTrace);

                return GetStackTrace(stackTrace, exception.InnerException);
            }

            return stackTrace;
        }
        #endregion
    }
}
