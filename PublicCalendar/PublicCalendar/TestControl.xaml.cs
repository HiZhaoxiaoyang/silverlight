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

namespace PublicCalendar
{
    public partial class TestControl : UserControl
    {
        public TestControl()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(TestControl_Loaded);
        }

        void TestControl_Loaded(object sender, RoutedEventArgs e)
        {
            PublicCalendar.WCFServ.UtilitiesCalendarClient wcc = new PublicCalendar.WCFServ.UtilitiesCalendarClient();
            wcc.GetDailyCNCompleted += new EventHandler<PublicCalendar.WCFServ.GetDailyCNCompletedEventArgs>(wcc_GetDailyCNCompleted);
            wcc.GetDailyCNAsync();
            //throw new NotImplementedException();
        }

        void wcc_GetDailyCNCompleted(object sender, PublicCalendar.WCFServ.GetDailyCNCompletedEventArgs e)
        {
            var ay = e.Result.Where(w => w.HolidayFlag.ToString().Equals("Y"));
            tl.Text += " " + ay.Count();
            grid1.ItemsSource = ay;
            //throw new NotImplementedException();
        }
    }
}
