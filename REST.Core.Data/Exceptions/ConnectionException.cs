using System;

namespace REST.Core.Data
{
    public class ConnectionException : DataLayerException
    {
        #region Constructors
            public ConnectionException(string oracleStackTrace) :
                        base("Connection Exception", oracleStackTrace) { }
	    #endregion
    }
}
