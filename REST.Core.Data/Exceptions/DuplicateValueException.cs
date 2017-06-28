using System;

namespace REST.Core.Data
{
    public class DuplicateValueException : DataLayerException
    {
        #region Constructors
            public DuplicateValueException(string oracleStackTrace) : 
                base("Duplicate Value Exception", oracleStackTrace) { }
	    #endregion
    }
}
