using System;

namespace REST.Core.Data
{
    public class MemoryException : DataLayerException
    {
        #region Constructors
            public MemoryException(string oracleStackTrace) :
                        base("Memory Exception", oracleStackTrace) { }
	    #endregion
    }
}
