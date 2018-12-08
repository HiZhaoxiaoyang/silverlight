namespace Telerik.Windows.Examples.Examples.Calendar.SelectionRangeConstraints
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using Telerik.Windows.Controls;
    using Telerik.Windows.QuickStart;

    public class Example : Telerik.Windows.QuickStart.Example
    {
        private bool _contentLoaded;
        internal RadCalendar calendarConstraints;
        internal RadCalendar calendarRange;
        internal CheckBox cbxEnabledRangeCalendar;

        public Example()
        {
            this.InitializeComponent();
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (!this._contentLoaded)
            {
                this._contentLoaded = true;
                Application.LoadComponent(this, new Uri("/Examples.Calendar;component/Examples/Calendar/SelectionRangeConstraints/Example.xaml", UriKind.Relative));
                this.calendarRange = (RadCalendar) base.FindName("calendarRange");
                this.calendarConstraints = (RadCalendar) base.FindName("calendarConstraints");
                this.cbxEnabledRangeCalendar = (CheckBox) base.FindName("cbxEnabledRangeCalendar");
            }
        }

        private void OnEnabledRangeCalendar(object sender, RoutedEventArgs e)
        {
            this.calendarRange.IsEnabled = this.cbxEnabledRangeCalendar.IsChecked.Value;
        }

        private void OnSelectionRangeLoaded(object sender, RoutedEventArgs e)
        {
            this.calendarConstraints.SelectableDateStart = new DateTime?(DateTime.Today.AddDays(-20.0));
            this.calendarConstraints.SelectableDateEnd = new DateTime?(DateTime.Today.AddDays(70.0));
            this.calendarConstraints.DisplayDateStart = new DateTime?(DateTime.Today.AddDays(-160.0));
            this.calendarConstraints.DisplayDateEnd = new DateTime?(DateTime.Today.AddDays(160.0));
        }
    }
}

