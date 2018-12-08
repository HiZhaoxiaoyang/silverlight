using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Threading;
using System.Globalization;
using Examples.Calendar;
using Telerik.Windows.Controls.Calendar;
using System.Windows.Markup;
using System.Windows.Threading;

namespace PublicCalendar
{
    public partial class Page : UserControl
    {

        private int firtDayOfWeek=1;
        private Boolean phDay;
        //private SpecialHoliday sh;
        private Array arryCode;
        private Array arryDate;
        private Array arryDesc;

        private WCFServ.UtilitiesCalendarClient getServ;
        private Array pwcPHDate;
        private Array pwcPHDesc;



        //private List<DayTemplate> pwcHKPH;
        //private List<DayTemplate> pwcMAPH;
        public int specDay;

        public Page()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Page_Loaded);
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {                        
            /*
             * Data Initialize
             * */
            #region load WCF

            getServ = new PublicCalendar.WCFServ.UtilitiesCalendarClient();
            countryCode.SelectedIndex = 0;

            //getServ.GetCalendarCompleted += new EventHandler<PublicCalendar.WCFServ.GetCalendarCompletedEventArgs>(getServ_GetCalendarCompleted);
            //getServ.GetCalendarAsync();

            //getServ.GetDailyCNCompleted += new EventHandler<PublicCalendar.WCFServ.GetDailyCNCompletedEventArgs>(getServ_GetDailyCNCompleted);
            //getServ.GetDailyCNAsync();

            #endregion load WCF

            /* Initialization */
            tkCalendar.SelectionChanged += new Telerik.Windows.Controls.SelectionChangedEventHandler(tkCalendar_SelectionChanged);
            //tkCalendar.Style=StyleTypedPropertyAttribute

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();


            //interCal.DisplayDate = new DateTime(2009, 3, 11); 
            interCal.BlackoutDates.AddDatesInPast();
            //interCal.CalendarDayButtonStyle.SetValue(interCal, interCal.SelectedDate.Value.Day);

            /* Set current available language */
            tkCalendar.Culture = Thread.CurrentThread.CurrentUICulture;


            /*Region Selection*/
            countryCode.SelectionChanged += new SelectionChangedEventHandler(countryCode_SelectionChanged);

            /* Set first day of week. */
            tkCalendar.FirstDayOfWeek = (DayOfWeek)firtDayOfWeek;

            //Make sure that more than one date can be selected:
            //tkCalendar.SelectionMode = Telerik.Windows.Controls.SelectionMode.Extended;
            ////Which month is it today?
            //int thisMonthIndex = DateTime.Today.AddMonths(11).Month;
            //DateTime dayOfMonth = new DateTime(DateTime.Today.Year, thisMonthIndex, 1);
            //while (thisMonthIndex == dayOfMonth.Month)
            //{
            //    //Add the date if is a Mon - Fri week day:
            //    if (dayOfMonth.DayOfWeek != DayOfWeek.Sunday && dayOfMonth.DayOfWeek != DayOfWeek.Saturday)
            //    {
            //        tkCalendar.SelectedDates.Add(dayOfMonth);
            //    }
            //    dayOfMonth = dayOfMonth.AddDays(1);
            //}
        }

        private int inte;
        void timer_Tick(object sender, EventArgs e)
        {
           // inte++;
           // sh = new SpecialHoliday();
           // testTxt.Text = inte.ToString();
           // sh.PubHoliday = 20;
           // //Telerik.Windows.Examples.Examples.Calendar.FirstLook.DisableWeekendsSelection dw = new Telerik.Windows.Examples.Examples.Calendar.FirstLook.DisableWeekendsSelection();
           //// dw.SpecialDay.LoadContent().SetValue(
           // //throw new NotImplementedException();

           // /* tkCalendar Template */
           // /*Button rec = new Button();
           // LayoutRoot.Children.Add(rec);
           // rec.Width = rec.Height = 300;
           // rec.Content = "fa;sdkfj;asdkf;asdkf";*/

           // Telerik.Windows.Examples.Examples.Calendar.FirstLook.DisableWeekendsSelection dw = new Telerik.Windows.Examples.Examples.Calendar.FirstLook.DisableWeekendsSelection();
           // DataTemplate dtl = new DataTemplate();

           // TextBlock tbk = new TextBlock();
           // tbk.Width = tbk.Height = 50;
           // tbk.Text = "00";
           // tbk.Foreground = new SolidColorBrush(Colors.Red);

           // //tkCalendar.DayTemplateSelector.SelectTemplate(dtl, dw.DefaultTemplate);
           // tkCalendar.DayTemplateSelector.SelectTemplate(tbk, sh.SpecialDay);
           // //tkCalendar.DayTemplateSelector.SelectTemplate(dtl,dw.SpecialDay);

        }

        void countryCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            /* Region Selection */
            switch (countryCode.SelectedItem.ToString())
            {
                case "CN":
                    /*Get CN PH*/
                    getServ.GetDailyCNCompleted += new EventHandler<PublicCalendar.WCFServ.GetDailyCNCompletedEventArgs>(getServ_GetDailyCNCompleted);
                    getServ.GetDailyCNAsync();

                    //Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-Hans");
                    tkCalendar.Culture = new CultureInfo("zh-Hans");
                    Detailer.counCode.Text = "区域代码 : CN";
                    //Detailer.counDesc.Text = "阿斯蒂芬阿三点多久阿斯蒂芬阿三点开发，阿地方，阿三点发送到发送到发送到阿三点发点。阿三点。阿弟。阿三点阿斯蒂芬阿三点。";
                    //tkCalendar.SelectedDates.Add(e.Result.ElementAt<WCFServ.Calendar>(1).Date);
                    break;

                case "HK":
                    /*Get HK PH*/
                    getServ.GetDailyHKCompleted += new EventHandler<PublicCalendar.WCFServ.GetDailyHKCompletedEventArgs>(getServ_GetDailyHKCompleted);
                    getServ.GetDailyHKAsync();

                    //Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-Hant");
                    tkCalendar.Culture = new CultureInfo("zh-Hant");
                    Detailer.counCode.Text = "区域代码 : HK";
                    //Detailer.counDesc.Text = "The leave year is the calender year and all staff are expected to take their full entitlement during the year which it relates.HK HK HK HK HK HK HK ";
                    break;

                case "MA":
                    /*Get MA PH*/
                    getServ.GetDailyMACompleted += new EventHandler<PublicCalendar.WCFServ.GetDailyMACompletedEventArgs>(getServ_GetDailyMACompleted);
                    getServ.GetDailyMAAsync();
                    //Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-Hant");
                    tkCalendar.Culture = Thread.CurrentThread.CurrentUICulture;
                    Detailer.counCode.Text = "Country Code : MA";
                    //Detailer.counDesc.Text = "The leave year is the calender year and all staff are expected to take their full entitlement during the year which it relates.MA MA MA MA MA MA ";
                    break;

                default:
                    break;
            }
            //tkCalendar.Culture = Thread.CurrentThread.CurrentUICulture;
            //tkCalendar.SelectedDates.Add(e.Result.ElementAt(1).Date);
            //throw new NotImplementedException();
        }

        void tkCalendar_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
        {
            /* Selected Date to curDate control */
            string curDay;
            curDay = tkCalendar.SelectedDate.Value.Day.ToString();// tkCalendar.SelectedDate.ToString().Substring(tkCalendar.SelectedDate.ToString().LastIndexOf("-") + 1, tkCalendar.SelectedDate.ToString().IndexOf("-") - 2);
            curDate.strTXT.Text = tkCalendar.SelectedDate.ToString().Substring(0, tkCalendar.SelectedDate.ToString().LastIndexOf("-")) + " *" + tkCalendar.SelectedDate.Value.DayOfWeek.ToString();
            if (curDay.Length<2)
            {
                curDay = "0" + curDay;
            }
            curDate.uperT.Text = curDate.calT.Text = curDate.downT.Text = curDay;


            /* Judge public holiday. */
            if (tkCalendar.SelectedDate.Value.DayOfWeek.ToString() == "Saturday" || tkCalendar.SelectedDate.Value.DayOfWeek.ToString() == "Sunday" || DateTime.Now.DayOfWeek.ToString() == specDay.ToString())
            {
                //this.tkCalendar.SelectedDate.
                //tkCalendar.SelectedDate.Value
                phDay = true;
            }
            else
            {
                phDay = false;
            }
            
            /* Detail panel */
            if (Detailer.step % 2 == 1) Detailer.step = 0; else Detailer.step = 1;
            Detailer.detail_loader.Begin();
            Detailer.ph.Text = "Public Holiday : " + phDay.ToString();

            /* Set PH Desc to Detailer */
            for (int i = 0; i < pwcPHDate.Length; i++)
            {
                if (tkCalendar.SelectedDate.Value.Date == Convert.ToDateTime(pwcPHDate.GetValue(i)))
                {
                    Detailer.counDesc.Text = pwcPHDesc.GetValue(i).ToString();
                    break;
                }
                else
                {
                    Detailer.counDesc.Text = "Work Day...";
                }
            }

            //for (int i = 0; i < arryDesc.Length; i++)
            //{
            //    Detailer.counDesc.Text = arryDesc.GetValue(i).ToString();
            //}
            
            
            //testTxt.Text = e.Handled.ToString();
            //tkCalendar.SelectedDates.Add(DateTime.Today);
            //testTxt.Text = phDay.ToString() + "@";// +this.tkCalendar.SelectedDate.Value.DayOfWeek.ToString() + "*" + DateTime.Now.DayOfWeek.ToString() + " " + curDay + ";" + tkCalendar.SelectedDate.ToString() + "," + tkCalendar.SelectedDate.ToString();
            //throw new NotImplementedException();
        }


        /*
         * Data Loader
         * */
        #region WCF loader

        void getServ_GetCalendarCompleted(object sender, PublicCalendar.WCFServ.GetCalendarCompletedEventArgs e)
        {
            /* Get collection to test grid */
            dg.ItemsSource = e.Result.ToList();

            /*
             * get PH from sql table 
             */
            //sh = new SpecialHoliday();

            /* Get public holiday Date */
            arryDate = e.Result.Where(pp => pp.PH.ToString().Equals("Y")).Select(dt => dt.Date).ToArray();
            //PrintValues(arryPH as Object[]);
            
            /* Get public holiday description */
            arryDesc = e.Result.Where(w => w.PH.ToString().Equals("Y")).Select(s => s.Desc).ToArray();

            /* Get Country Country Code */
            arryCode = e.Result.Where(cd => cd.PH.ToString().Equals("Y")).Select(cc => cc.CountryCode).ToArray();
            
            testBox.ItemsSource = arryDate;
            //for (int i = 0; i < testBox.Items.Count(); i++)
            //{
            //    //sh.pubHoliday = Convert.ToInt32(testBox.Items[i]);
            //    testTxt.Text += Convert.ToDateTime(testBox.Items[i]).ToString() + " SpecialHoliday.cs:" + curDate.curDateDay.ToString();
            //}


            /* Default Detail */
            if (DateTime.Now.DayOfWeek.ToString() == "Saturday" || DateTime.Now.DayOfWeek.ToString() == "Sunday" || DateTime.Now.DayOfWeek.ToString() == specDay.ToString())
            {
                phDay = true;
            }
            else
            {
                phDay = false;
            }
            Detailer.counCode.Text = "Country Code : CNNN";
            Detailer.counDesc.Text = "The leave year is the calender year and all staff are expected to take their full entitlement during the year which it relates.EN EN EN EN EN EN EN EN EN ";
            Detailer.ph.Text = "Public Holiday : " + phDay.ToString();
        
        }

        private void PrintValues(Object[] myArr)
        {
            //sh.pubHoliday = 15;
            foreach (Object i in myArr)
            {
                //testTxt.Text += i.ToString();
                //Console.Write("\t{0}", i);
            }
            //Console.WriteLine();
        }


        void getServ_GetDailyCNCompleted(object sender, PublicCalendar.WCFServ.GetDailyCNCompletedEventArgs e)
        {

            pwcPHDate = e.Result.Where(o => o.HolidayFlag.ToString().Equals("Y")).Select(d => d.WorkDate).ToArray();
            pwcPHDesc = e.Result.Where(wd => wd.HolidayFlag.ToString().Equals("Y")).Select(dsc => dsc.Remarks).ToArray();


            /*Test Method*/
            testBox.ItemsSource = pwcPHDate;
            dg.ItemsSource = e.Result;

            /*pwcCNPH = new List<DayTemplate>();
            pwcCNPH.Add(new DayTemplate() { 
                WorkDate= Convert.ToDateTime(e.Result.Where(o=>o.HolidayFlag.ToString().Equals("Y")).Select(wd=>wd.WorkDate)),
                DateStatus = e.Result.Where(o => o.HolidayFlag.ToString().Equals("Y")).Select(ds=>ds.DateStatus).ToString(),
                HolidayFlag = e.Result.Where(o => o.HolidayFlag.ToString().Equals("Y")).Select(hf=>hf.HolidayFlag).ToString(),
                Remarks = e.Result.Where(o => o.HolidayFlag.ToString().Equals("Y")).Select(rm=>rm.Remarks).ToString()
            });*/

            //DataGrid dd = new DataGrid();
            //dd.Width = dd.Height = 300;
            //LayoutRoot.Children.Add(dd);
            //dd.ItemsSource = pwcCNPH;
        }

        void getServ_GetDailyMACompleted(object sender, PublicCalendar.WCFServ.GetDailyMACompletedEventArgs e)
        {
            pwcPHDate = e.Result.Where(o => o.HolidayFlag.ToString().Equals("Y")).Select(d => d.WorkDate).ToArray();
            pwcPHDesc = e.Result.Where(wd => wd.HolidayFlag.ToString().Equals("Y")).Select(dsc => dsc.Remarks).ToArray();

            //throw new NotImplementedException();
        }

        void getServ_GetDailyHKCompleted(object sender, PublicCalendar.WCFServ.GetDailyHKCompletedEventArgs e)
        {
            pwcPHDate = e.Result.Where(o => o.HolidayFlag.ToString().Equals("Y")).Select(d => d.WorkDate).ToArray();
            pwcPHDesc = e.Result.Where(wd => wd.HolidayFlag.ToString().Equals("Y")).Select(dsc => dsc.Remarks).ToArray();

            //throw new NotImplementedException();
        }



        void getServ_DoWorkCompleted(object sender, PublicCalendar.WCFServ.DoWorkCompletedEventArgs e)
        {
            tb.Text = e.Result;
            //throw new NotImplementedException();
        }

        #endregion WCF loader


        /**
         *  Controls Interaction
         * */
        #region selection control
        private void SelectionEvents()
        {

        }
        #endregion selection control

        #region current date control
        private void CurDateEvents()
        {

        }
        #endregion current date control
        
        #region tk calendar control
        private void CalEvents()
        {

        }
        #endregion tk calendar control


        /**
         *  Interative with XAML
         * */
        #region Mouse & Keyboard
        //Country code comboBox
        private string[] counCode = new string[]{"CN","HK","MA"};
        private void countryCode_Loaded(object sender, RoutedEventArgs e)
        {
            //testTxt.Text = counCode[0].ToString() + counCode[1].ToString() + counCode[2].ToString();
            countryCode.ItemsSource = counCode.ToList();
            countryCode.SelectedIndex = 0;
        }

        /* Calendar create complation */
        private void tkCalendar_Loaded(object sender, RoutedEventArgs e)
        {
            /* tkCalendar Template */
            /*Button rec = new Button();
            LayoutRoot.Children.Add(rec);
            rec.Width = rec.Height = 300;
            rec.Content = "fa;sdkfj;asdkf;asdkf";*/

            //Telerik.Windows.Examples.Examples.Calendar.FirstLook.DisableWeekendsSelection dw
            //    = new Telerik.Windows.Examples.Examples.Calendar.FirstLook.DisableWeekendsSelection();

            /*DWS dw = new DWS();

            TextBlock tbk = new TextBlock();
            tbk.Width = tbk.Height = 50;
            tbk.Text = "00";
            tbk.Foreground = new SolidColorBrush(Colors.Red);

            DataTemplate dtl = new DataTemplate();
            //dtl.LoadContent();

            string xaml ="<TextBlock Text='{Binding Text}' Foreground='#FFFAF8F8'/>";
            dtl = (DataTemplate)XamlReader.Load(xaml);
            dtl.LoadContent();


            //testTxt.Text = dw.dwstxt;
            tkCalendar.DayTemplateSelector.SelectTemplate(dtl, dw.DefaultTemplate);
            //tkCalendar.DayTemplateSelector.SelectTemplate(tbk, dw.SpecialDay);
            tkCalendar.DayTemplateSelector.SelectTemplate(dtl,dw.SpecialDay);*/


            //tkCalendar.DayButtonStyleSelector = Telerik.Windows.Examples.Examples.Calendar.FirstLook.DisableWeekendsSelection();
            //for (int i = 0; i < DateTime.Now.Year; i++)
            //{
            //    tkCalendar.SelectedDates.Add(DateTime.Now.AddDays(i)
            //}

            //curDate.strTXT.Text = tkCalendar.SelectedDate.ToString().Substring(0, tkCalendar.SelectedDate.ToString().IndexOf(" "));
            //curDate.uperT.Text = curDate.calT.Text = curDate.downT.Text = tkCalendar.SelectedDate.ToString().Substring(tkCalendar.SelectedDate.ToString().LastIndexOf("-") + 1, tkCalendar.SelectedDate.ToString().IndexOf(" "));
        }

        /* Test Data load & Write (Data log properties) */
        private void dg_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //((WCFServ.Calendar)e.Row.DataContext).PropertyChanged += 
            //    new System.ComponentModel.PropertyChangedEventHandler(Page_PropertyChanged);
        }

        private void dg_UnloadingRow(object sender, DataGridRowEventArgs e)
        {
            //((WCFServ.Calendar)e.Row.DataContext).PropertyChanged-=
            //    new System.ComponentModel.PropertyChangedEventHandler(Page_PropertyChanged);
        }

        void Page_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            WCFServ.Calendar calServ = sender as WCFServ.Calendar;
            var calClient = new WCFServ.UtilitiesCalendarClient();
            calClient.UpdatePublicDateAsync(calServ, calServ.CountryCode);
            calClient.UpdatePublicDateCompleted += 
                new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(calClient_UpdatePublicDateCompleted);
            //throw new NotImplementedException();
        }


        void calClient_UpdatePublicDateCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Public Calendar Data Updated ! ");
            //throw new NotImplementedException();
        }

        #endregion Mouse & Keyboard


    }

    /*public class SpecialHoliday : Telerik.Windows.Controls.DataTemplateSelector
    {
        public int pubHoliday=15;

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            CalendarButtonContent content = item as CalendarButtonContent;

            //(new PublicCalendar.Page()).testTxt.Text = "Test Spec";

            if (content != null)
            {
                if (content.Date.DayOfWeek == DayOfWeek.Saturday || content.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    content.IsEnabled = false;
                    //content.ButtonType = Telerik.Windows.Controls.Calendar.CalendarButton;
                }
            }

            //Some days are special:
            if (content.Date.Day == pubHoliday && content.ButtonType == CalendarButtonType.Date)
            {
                return SpecialDay;
            }

            return DefaultTemplate;
        }

        private DataTemplate defaultTemplate;
        public DataTemplate DefaultTemplate
        {
            get
            {
                return defaultTemplate;
            }
            set
            {
                defaultTemplate = value;
            }
        }

        private DataTemplate specialDay;
        public DataTemplate SpecialDay
        {
            get
            {
                return specialDay;
            }
            set
            {
                this.specialDay = value;
            }
        }
    }
    */
}

