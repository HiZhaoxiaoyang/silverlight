using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls.Calendar;
using System.Threading;


namespace PublicCalendar
{
    public class SpecialHoliday :Telerik.Windows.Controls.DataTemplateSelector //,System.Windows.Controls.UserControl
    {
        //public int pubHoliday=12;
        private Boolean IsGetDate=false;

        public SpecialHoliday()
        {
            //System.Console.Out.WriteLine();
            //PubHoliday = 5;
            WCFServ.UtilitiesCalendarClient wchl = new PublicCalendar.WCFServ.UtilitiesCalendarClient();
            wchl.DoWorkCompleted += new EventHandler<PublicCalendar.WCFServ.DoWorkCompletedEventArgs>(wchl_DoWorkCompleted);
            wchl.DoWorkAsync();
        }

        void wchl_DoWorkCompleted(object sender, PublicCalendar.WCFServ.DoWorkCompletedEventArgs e)
        {
            //System.Console.Out.WriteLine();
            PubHoliday = 10;// e.Result.Length;
            IsGetDate = true;

            //throw new NotImplementedException();
        }


        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            CalendarButtonContent content = item as CalendarButtonContent;
            //if (IsGetDate)
            //{
                if (content != null)
                {
                    if (content.Date.DayOfWeek == DayOfWeek.Saturday || content.Date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        //content.IsEnabled = false;
                        content.Text = "S";
                    }
                }

                //Some days are special:
                //Thread.Sleep(3000);
                if (content.Date.Day == PubHoliday && content.ButtonType == CalendarButtonType.Date)
                {
                    //content.Text = "current content";
                    content.IsEnabled = true;
                    return SpecialDay;
                }
            //}

            return DefaultTemplate;
        }

        private int pubHoliday;
        public int PubHoliday
        {
            get {
                //pubHoliday = 8;
                return pubHoliday;
            }
            set {

                pubHoliday = value;
            }
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
}
