using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Runtime.Serialization;

namespace PublicCalendar.Web
{
    [DataContract]
    public class PHTemplate
    {
        [DataMember]
        public DateTime WorkDate { get; set; }

        [DataMember]
        public String HolidayFlag { get; set; }

        [DataMember]
        public String DateStatus { get; set; }

        [DataMember]
        public String Remarks { get; set; }

    }
}
