using System;

namespace REST.Core.Data
{
    public class OnDeleteCascadeException : DataLayerException
    {
        #region Constructors
        public OnDeleteCascadeException(string oracleStackTrace) :
            base("On Delete Cascade Exception", oracleStackTrace) { }
	    #endregion
    }
}
