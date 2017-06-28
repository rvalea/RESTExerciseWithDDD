using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Core.Data
{
    public class RelatedRowsFoundException : DataLayerException
    {
        #region Constructors
            public RelatedRowsFoundException(string oracleStackTrace) :
                base("Related Rows Found Exception", oracleStackTrace) { }
        #endregion
    }
}
