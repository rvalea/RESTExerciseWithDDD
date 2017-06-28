using System;

namespace REST.Core.Data
{
    public class NotNullException : DataLayerException
    {
        #region Constructors
            public NotNullException(string oracleStackTrace) :
                        base("Not Null Exception", oracleStackTrace) { }
	    #endregion
    }
}
