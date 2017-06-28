using System;

namespace REST.Core.Data
{
    public class CheckException : DataLayerException
    {
        #region Constructors
            public CheckException(string oracleStackTrace) : 
                base("Check Exception", oracleStackTrace) { }
	    #endregion
    }
}
