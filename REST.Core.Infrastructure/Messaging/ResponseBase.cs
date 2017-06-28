using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace REST.Core.Infrastructure.Messaging
{
    [DataContract]
    public abstract class ResponseBase
    {
        #region Properties
        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public IEnumerable<string> ValidationMessages { get; set; }
        #endregion
    }

}