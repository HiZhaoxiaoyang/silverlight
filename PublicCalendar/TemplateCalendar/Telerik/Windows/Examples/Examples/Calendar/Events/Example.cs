namespace Telerik.Windows.Examples.Examples.Calendar.Events
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using Telerik.Windows.Controls;
    using Telerik.Windows.Controls.Calendar;
    using Telerik.Windows.QuickStart;

    public class Example : Telerik.Windows.QuickStart.Example
    {
        private bool _contentLoaded;
        internal Button btnClear;
        internal RadCalendar calendar;
        internal TextBlock output;

        public Example()
        {
            this.InitializeComponent();
        }

        private void BindEvents()
        {
            this.calendar.DisplayDateChanged += new EventHandler<CalendarDateChangedEventArgs>(this.calendar_DisplayDateChanged);
            this.calendar.DisplayModeChanged += new EventHandler<CalendarModeChangedEventArgs>(this.calendar_DisplayModeChanged);
            this.calendar.SelectionChanged += new Telerik.Windows.Controls.SelectionChangedEventHandler(this.calendar_SelectionChanged);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.ClearOutputEvents();
            this.btnClear.Opacity = 0.0;
        }

        private void calendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            this.Log("DisplayDateChanged");
        }

        private void calendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            this.Log("DisplayModeChanged");
        }

        private void calendar_Loaded(object sender, RoutedEventArgs e)
        {
            this.Log("Loaded");
        }

        private void calendar_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.Log("SelectionChanged With:");
            this.Log(" Added Dates:");
            foreach (DateTime date in e.AddedItems)
            {
                this.Log(date.ToShortDateString());
            }
            this.Log("Removed Dates:");
            foreach (DateTime date in e.RemovedItems)
            {
                this.Log(date.ToShortDateString());
            }
        }

        private void ClearOutputEvents()
        {
            this.output.Text = "Calendar Events:";
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (!this._contentLoaded)
            {
                this._contentLoaded = true;
                Application.LoadComponent(this, new Uri("/Examples.Calendar;component/Examples/Calendar/Events/Example.xaml", UriKind.Relative));
                this.output = (TextBlock) base.FindName("output");
                this.btnClear = (Button) base.FindName("btnClear");
                this.calendar = (RadCalendar) base.FindName("calendar");
            }
        }

        private void Log(string e)
        {
            this.output.Text = this.output.Text + "\n" + DateTime.Now.ToString() + "[" + e + "]";
            this.btnClear.Opacity = 1.0;
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            this.BindEvents();
            this.ClearOutputEvents();
        }
    }
}

