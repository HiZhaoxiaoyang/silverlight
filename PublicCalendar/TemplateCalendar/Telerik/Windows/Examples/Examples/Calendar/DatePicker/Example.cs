namespace Telerik.Windows.Examples.Examples.Calendar.DatePicker
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Media.Animation;
    using Telerik.Windows.Controls;
    using Telerik.Windows.QuickStart;

    public class Example : Telerik.Windows.QuickStart.Example
    {
        private bool _contentLoaded;
        internal RadDatePicker datePicker;

        public Example()
        {
            this.InitializeComponent();
            this.datePicker.SelectedDate = new DateTime?(DateTime.Today);
            Storyboard sb = new Storyboard();
            sb.Duration = TimeSpan.FromSeconds(1.5);
            sb.Completed += new EventHandler(this.OnStoryboardCompleted);
            sb.Begin();
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (!this._contentLoaded)
            {
                this._contentLoaded = true;
                Application.LoadComponent(this, new Uri("/Examples.Calendar;component/Examples/Calendar/DatePicker/Example.xaml", UriKind.Relative));
                this.datePicker = (RadDatePicker) base.FindName("datePicker");
            }
        }

        private void OnStoryboardCompleted(object sender, EventArgs e)
        {
            this.datePicker.IsDropDownOpen = true;
        }
    }
}

