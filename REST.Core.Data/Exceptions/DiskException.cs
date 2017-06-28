using System;

namespace REST.Core.Data
{
    public class DiskException : DataLayerException
    {
        #region Constructors
        public DiskException(string oracleStackTrace) :
            base("Disk Exception", oracleStackTrace) { }
	    #endregion
    }
}
