using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PublicCalendar
{
	public partial class CurDate : UserControl
	{
        public int curDateDay=18;
        //public String currentDay;
		public CurDate()
		{
			// Required to initialize variables
			InitializeComponent();
            this.Loaded += new RoutedEventHandler(CurDate_Loaded);
		}

        void CurDate_Loaded(object sender, RoutedEventArgs e)
        {
            strTXT.Text = DateTime.Today.Date.ToString().Substring(0, DateTime.Today.Date.ToString().LastIndexOf("-")) + " *" + DateTime.Now.DayOfWeek.ToString();
            uperT.Text = calT.Text = downT.Text = DateTime.Now.Day.ToString();
            //uperT.Text = calT.Text = downT.Text= currentDay;
            //throw new NotImplementedException();
        }
	}
}