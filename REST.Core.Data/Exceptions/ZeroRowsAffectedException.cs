using System;

namespace REST.Core.Data
{
    public class ZeroRowsAffectedException : DataLayerException
    {
        #region Constructors
            public ZeroRowsAffectedException(string oracleStackTrace) :
                        base("Zero Rows Affected Exception", oracleStackTrace) { }
	    #endregion
    }
}
