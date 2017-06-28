using System;

namespace REST.Core.Data
{
    public class UnhandledException : DataLayerException
    {
        #region Constructors
            public UnhandledException(string oracleStackTrace) :
                        base("Unhandled Exception", oracleStackTrace) { }
	    #endregion
    }
}
