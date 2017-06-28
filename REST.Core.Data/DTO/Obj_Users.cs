using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Core.Data
{
    using System;
    using Oracle.DataAccess.Client;
    using Oracle.DataAccess.Types;
    using System.Xml.Serialization;
    using System.Xml.Schema;

    public class OBJ_USER : INullable, IOracleCustomType, IXmlSerializable
    {

        private bool m_IsNull;

        private decimal m_USER_ID;

        private bool m_USER_IDIsNull;

        private string m_USER_NAME;

        private System.DateTime m_BIRTHDAY_DATE;

        private bool m_BIRTHDAY_DATEIsNull;

        public OBJ_USER()
        {
            // TODO : Add code to initialise the object
            this.m_BIRTHDAY_DATEIsNull = true;
            this.m_USER_IDIsNull = true;
        }

        public OBJ_USER(string str)
        {
            // TODO : Add code to initialise the object based on the given string 
        }

        public virtual bool IsNull
        {
            get
            {
                return this.m_IsNull;
            }
        }

        public static OBJ_USER Null
        {
            get
            {
                OBJ_USER obj = new OBJ_USER();
                obj.m_IsNull = true;
                return obj;
            }
        }

        [OracleObjectMappingAttribute("USER_ID")]
        public decimal USER_ID
        {
            get
            {
                return this.m_USER_ID;
            }
            set
            {
                this.m_USER_ID = value;
            }
        }

        public bool USER_IDIsNull
        {
            get
            {
                return this.m_USER_IDIsNull;
            }
            set
            {
                this.m_USER_IDIsNull = value;
            }
        }

        [OracleObjectMappingAttribute("USER_NAME")]
        public string USER_NAME
        {
            get
            {
                return this.m_USER_NAME;
            }
            set
            {
                this.m_USER_NAME = value;
            }
        }

        [OracleObjectMappingAttribute("BIRTHDAY_DATE")]
        public System.DateTime BIRTHDAY_DATE
        {
            get
            {
                return this.m_BIRTHDAY_DATE;
            }
            set
            {
                this.m_BIRTHDAY_DATE = value;
            }
        }

        public bool BIRTHDAY_DATEIsNull
        {
            get
            {
                return this.m_BIRTHDAY_DATEIsNull;
            }
            set
            {
                this.m_BIRTHDAY_DATEIsNull = value;
            }
        }

        public virtual void FromCustomObject(Oracle.DataAccess.Client.OracleConnection con, System.IntPtr pUdt)
        {
            Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "USER_NAME", this.USER_NAME);
            if ((BIRTHDAY_DATEIsNull == false))
            {
                Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "BIRTHDAY_DATE", this.BIRTHDAY_DATE);
            }
            if ((USER_IDIsNull == false))
            {
                Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "USER_ID", this.USER_ID);
            }
        }

        public virtual void ToCustomObject(Oracle.DataAccess.Client.OracleConnection con, System.IntPtr pUdt)
        {
            this.USER_NAME = ((string)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "USER_NAME")));
            this.BIRTHDAY_DATEIsNull = Oracle.DataAccess.Types.OracleUdt.IsDBNull(con, pUdt, "BIRTHDAY_DATE");
            if ((BIRTHDAY_DATEIsNull == false))
            {
                this.BIRTHDAY_DATE = ((System.DateTime)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "BIRTHDAY_DATE")));
            }
            this.USER_IDIsNull = Oracle.DataAccess.Types.OracleUdt.IsDBNull(con, pUdt, "USER_ID");
            if ((USER_IDIsNull == false))
            {
                this.USER_ID = ((decimal)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "USER_ID")));
            }
        }

        public virtual void ReadXml(System.Xml.XmlReader reader)
        {
            // TODO : Read Serialized Xml Data
        }

        public virtual void WriteXml(System.Xml.XmlWriter writer)
        {
            // TODO : Serialize object to xml data
        }

        public virtual XmlSchema GetSchema()
        {
            // TODO : Implement GetSchema
            return null;
        }

        public override string ToString()
        {
            // TODO : Return a string that represents the current object
            return "";
        }

        public static OBJ_USER Parse(string str)
        {
            // TODO : Add code needed to parse the string and get the object represented by the string
            return new OBJ_USER();
        }
    }

    // Factory to create an object for the above class
    [OracleCustomTypeMappingAttribute("OBJ_USER")]
    public class OBJ_USERFactory : IOracleCustomTypeFactory
    {

        public virtual IOracleCustomType CreateObject()
        {
            OBJ_USER obj = new OBJ_USER();
            return obj;
        }
    }
}