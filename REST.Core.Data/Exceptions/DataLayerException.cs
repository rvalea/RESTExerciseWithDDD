using System;

namespace REST.Core.Data
{
    public class DataLayerException : Exception
    {
        #region Properties
        public string OracleStackTrace { get; set; }
        public Exception OriginalException { get; set; }
        #endregion

        #region Constructors
        public DataLayerException(string message, string oracleStackTrace)
            : base(message)
        {
            this.OracleStackTrace = oracleStackTrace;
        }
        #endregion

        #region Override
        public override string StackTrace
        {
            get
            {
                string originalStackTrace = OriginalException != null ? OriginalException.StackTrace : string.Empty;
                return string.Format("{0}{1}\r\nOriginal exception: {2}", OracleStackTrace, base.StackTrace, originalStackTrace);
            }
        }
        #endregion
    }
}
