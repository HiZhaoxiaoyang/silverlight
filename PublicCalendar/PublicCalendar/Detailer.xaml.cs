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
	public partial class Detailer : UserControl
	{
        public uint step;

		public Detailer()
		{
			// Required to initialize variables
			InitializeComponent();
            Loaded += new RoutedEventHandler(Detailer_Loaded);
		}

        void Detailer_Loaded(object sender, RoutedEventArgs e)
        {
            descArrow.MouseLeftButtonUp += new MouseButtonEventHandler(descArrow_MouseLeftButtonUp);
            //throw new NotImplementedException();
        }

        void descArrow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            step++;
            if (step % 2 == 1)
            {
                detail_collapse.Stop();
                detail_loader.Begin();
            }
            else
            {
                detail_loader.Stop();
                detail_collapse.Begin();
            }
            //throw new NotImplementedException();
        }
	}
}