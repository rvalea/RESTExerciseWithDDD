using System;

namespace REST.Core.Data
{
    public class IntegrityContraintsException : DataLayerException
    {
        #region Constructors
            public IntegrityContraintsException(string oracleStackTrace) :
                        base("Integrity Contraints Exception", oracleStackTrace) { }
	    #endregion
    }
}
