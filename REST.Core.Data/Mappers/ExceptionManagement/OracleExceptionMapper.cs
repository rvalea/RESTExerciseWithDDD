using Oracle.DataAccess.Client;

namespace REST.Core.Data
{
    public static class DataLayerExceptionMapper
    {
        public static DataLayerException ConvertToDataLayerException(this OracleException oracleException)
        {
            switch (oracleException.Number)
            {
                case 1688:
                case 1653:
                case 1654:
                case 1536:
                case 1691:
                case 1631:
                case 1652:
                case 30036:
                case 25153:
                    return new DiskException(BuildExceptionMessage(oracleException)) { OriginalException = oracleException };

                case 1012:
                case 12154:
                case 1017:
                case 1005:
                case 18:
                case 20:
                case 12545:
                    return new ConnectionException(BuildExceptionMessage(oracleException)) { OriginalException = oracleException };

                case 6500:
                    return new MemoryException(BuildExceptionMessage(oracleException)) { OriginalException = oracleException };

                case 1:
                    return new DuplicateValueException(BuildExceptionMessage(oracleException)) { OriginalException = oracleException };

                case 1400:
                    return new NotNullException(BuildExceptionMessage(oracleException)) { OriginalException = oracleException };

                case 2290:
                    return new CheckException(BuildExceptionMessage(oracleException)) { OriginalException = oracleException };

                case 2291:
                    return new IntegrityContraintsException(BuildExceptionMessage(oracleException)) { OriginalException = oracleException };

                case 2292:
                    return new OnDeleteCascadeException(BuildExceptionMessage(oracleException)) { OriginalException = oracleException };

                case 20012:
                    return new ZeroRowsAffectedException(BuildExceptionMessage(oracleException)) { OriginalException = oracleException };

                case 20003:
                    return new RelatedRowsFoundException(BuildExceptionMessage(oracleException)) { OriginalException = oracleException };

                default:
                    return new UnhandledException(BuildExceptionMessage(oracleException)) { OriginalException = oracleException };
            }
        }

        private static string BuildExceptionMessage(OracleException oracleException)
        {
            return string.Format("{0}\n{1}", oracleException.Procedure, oracleException.Message);
        }

        public static DataLayerException ConvertToDataLayerException(int number, string procedure, string message)
        {
            switch (number)
            {
                case 1688:
                case 1653:
                case 1654:
                case 1536:
                case 1691:
                case 1631:
                case 1652:
                case 30036:
                case 25153:
                    return new DiskException(BuildExceptionMessage(procedure, message));

                case 1012:
                case 12154:
                case 1017:
                case 1005:
                case 18:
                case 20:
                case 12545:
                    return new ConnectionException(BuildExceptionMessage(procedure, message));

                case 6500:
                    return new MemoryException(BuildExceptionMessage(procedure, message));

                case 1:
                    return new DuplicateValueException(BuildExceptionMessage(procedure, message));

                case 1400:
                    return new NotNullException(BuildExceptionMessage(procedure, message));

                case 2290:
                    return new CheckException(BuildExceptionMessage(procedure, message));

                case 2291:
                    return new IntegrityContraintsException(BuildExceptionMessage(procedure, message));

                case 2292:
                    return new OnDeleteCascadeException(BuildExceptionMessage(procedure, message));

                case 20012:
                    return new ZeroRowsAffectedException(BuildExceptionMessage(procedure, message));

                case 20003:
                    return new RelatedRowsFoundException(BuildExceptionMessage(procedure, message));

                default:
                    return new UnhandledException(BuildExceptionMessage(procedure, message));
            }
        }

        private static string BuildExceptionMessage(string procedure, string message)
        {
            return string.Format("{0}\n{1}", procedure, message);
        }

    }
}