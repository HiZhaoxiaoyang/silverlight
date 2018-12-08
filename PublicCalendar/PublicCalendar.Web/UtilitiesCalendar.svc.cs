using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PublicCalendar.Web
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class UtilitiesCalendar
    {
        [OperationContract]
        public String DoWork()
        {
            // Add your operation implementation here
            return "Region";
        }

         /* FROM [Utilities].[dbo].[Calendar] */
        //[OperationContract]
        //public List<PHTemplate>  GetTemplate()
        //{
        //    var dt = new DataClassesDataContext();
        //    //if (DoWork() == "CN")
        //    //{
        //        var t = from tp in dt.DailyOTRate_CNs
        //                select tp;
        //    //}
        //    //return cn.Where(w => w.HolidayFlag.ToString().Equals("Y")).Select(r => r.Remarks).ToList();
        //    return t.Take(t.Count()).ToList();
        //}


        [OperationContract]
        public IEnumerable<Calendar> GetCalendar()
        {
            var gl = new DataClassesDataContext();
            var g = from ca in gl.Calendars
                    select
                        ca;
            return g.Take(g.Count()).ToList();
        }

        /* Update [Utilities].[dbo].[Calendar] from wcf */
        [OperationContract]
        public void UpdatePublicDate(Calendar cal)
        {
            DataClassesDataContext dc = new DataClassesDataContext();
            
            var bfCal = (from bc in dc.Calendars
                         where bc.CountryCode == cal.CountryCode
                         select bc).First();

            bfCal.CountryCode = cal.CountryCode;
            bfCal.Date = cal.Date;
            bfCal.Desc = cal.Desc;
            bfCal.PH = cal.PH;

            dc.SubmitChanges();
        }


        /* FROM [Utilities].[dbo].[DailyOTRate_CN] */
        [OperationContract]
        public List<DailyOTRate_CN> GetDailyCN()
        {
            var dcn = new DataClassesDataContext();
            var cn = from c in dcn.DailyOTRate_CNs
                     select c;
            //return cn.Where(w => w.HolidayFlag.ToString().Equals("Y")).Select(r => r.Remarks).ToList();
            return cn.Take(cn.Count()).ToList();
            }

        [OperationContract]
        public IEnumerable<DailyOTRate_HK> GetDailyHK()
        {
            var dhk = new DataClassesDataContext();
            var hk = from h in dhk.DailyOTRate_HKs select h;

            return hk.Take(hk.Count()).ToArray();
        }

        [OperationContract]
        public List<DailyOTRate_MA> GetDailyMA()
        {
            var dma = new DataClassesDataContext();
            var ma = from m in dma.DailyOTRate_MAs
                     select m;
            return ma.Take(ma.Count()).ToList();
        }


        /* Update PH from wcf */
        [OperationContract]
        public void UpdateTable(String code, DailyOTRate_CN dcn, DailyOTRate_HK dhk, DailyOTRate_MA dma, String amend)
        {

            DataClassesDataContext dcont = new DataClassesDataContext();

            switch (code)
            {
                case "CN":
                    var cnCode = (from cn in dcont.DailyOTRate_CNs
                                  where cn.WorkDate == dcn.WorkDate
                                  select cn).First();

                    cnCode.WorkDate = dcn.WorkDate;
                    cnCode.HolidayFlag = dcn.HolidayFlag;
                    cnCode.DateStatus = dcn.DateStatus;
                    cnCode.Remarks = dcn.Remarks;
                    break;

                case "HK":
                    var hkCode = (from hk in dcont.DailyOTRate_CNs
                                  where hk.WorkDate == dhk.WorkDate
                                  select hk).First();

                    hkCode.WorkDate = dhk.WorkDate;
                    hkCode.HolidayFlag = dhk.HolidayFlag;
                    hkCode.DateStatus = dhk.DateStatus;
                    hkCode.Remarks = dhk.Remarks;
                    break;

                case "MA":
                    var maCode = (from ma in dcont.DailyOTRate_CNs
                                  where ma.WorkDate == dma.WorkDate
                                  select ma).First();

                    maCode.WorkDate = dma.WorkDate;
                    maCode.HolidayFlag = dma.HolidayFlag;
                    maCode.DateStatus = dma.DateStatus;
                    maCode.Remarks = dma.Remarks;
                    break;
            }//switcher

            dcont.SubmitChanges();

            if (amend != null)
            {
                if (amend == "ADD")
                {
                    dcont.CreateDatabase();
                }
                if (amend == "MODIFY")
                {
                    dcont.SubmitChanges();
                }
                if (amend == "DELETE")
                {
                    dcont.DeleteDatabase();
                }
                //dcont.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, DailyOTRate_CN);
            }
        }
       
        // Add more operations here and mark them with [OperationContract]
    }
}
