namespace Telerik.Windows.Examples.Examples.Calendar.FirstLook
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Animation;
    using Telerik.Windows.Controls;
    using Telerik.Windows.QuickStart;

    public class Example : Telerik.Windows.QuickStart.Example
    {
        private bool _contentLoaded;
        private bool AllowUpdate = true;
        internal RadCalendar calendar;
        internal CheckBox ckbProhibitDates;
        internal RadDatePicker EndDatePicker;
        internal RadExpander RadExpander1;
        internal RadDatePicker StartDatePicker;
        internal TextBlock textBlockEndDate;
        internal TextBlock textBlockStartDate;

        public Example()
        {
            this.InitializeComponent();
            this.StartDatePicker.SelectedDate = new DateTime?(DateTime.Now.AddDays(27.0));
            this.EndDatePicker.SelectedDate = new DateTime?(DateTime.Now.AddDays(40.0));
            Storyboard storyBoard = new Storyboard();
            storyBoard.Duration = TimeSpan.FromSeconds(1.5);
            storyBoard.Completed += new EventHandler(this.OnStoryboardCompleted);
            storyBoard.Begin();
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (!this._contentLoaded)
            {
                this._contentLoaded = true;
                Application.LoadComponent(this, new Uri("/Examples.Calendar;component/Examples/Calendar/FirstLook/Example.xaml", UriKind.Relative));
                this.RadExpander1 = (RadExpander) base.FindName("RadExpander1");
                this.textBlockStartDate = (TextBlock) base.FindName("textBlockStartDate");
                this.textBlockEndDate = (TextBlock) base.FindName("textBlockEndDate");
                this.calendar = (RadCalendar) base.FindName("calendar");
                this.ckbProhibitDates = (CheckBox) base.FindName("ckbProhibitDates");
                this.StartDatePicker = (RadDatePicker) base.FindName("StartDatePicker");
                this.EndDatePicker = (RadDatePicker) base.FindName("EndDatePicker");
            }
        }

        private void OnCalendarSelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.AllowUpdate)
            {
                this.AllowUpdate = false;
                List<DateTime> items = this.calendar.SelectedDates.OrderBy<DateTime, DateTime>(delegate (DateTime dateTime) {
                    return dateTime;
                }).ToList<DateTime>();
                this.StartDatePicker.SelectedDate = new DateTime?(items.FirstOrDefault<DateTime>());
                this.EndDatePicker.SelectedDate = new DateTime?(items.LastOrDefault<DateTime>());
                this.AllowUpdate = true;
            }
        }

        private void OnCheckBoxClick(object sender, RoutedEventArgs e)
        {
            if (this.ckbProhibitDates.IsChecked.Value)
            {
                this.calendar.SelectableDateStart = new DateTime?(DateTime.Now);
            }
            else
            {
                this.calendar.SelectableDateStart = null;
            }
        }

        private void OnDatePickerSelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.StartDatePicker.SelectedDate.HasValue && this.EndDatePicker.SelectedDate.HasValue)
            {
                this.textBlockStartDate.Text = this.StartDatePicker.SelectedDate.Value.ToString("MMMM, dd, yyyy", CultureInfo.InvariantCulture);
                this.textBlockEndDate.Text = this.EndDatePicker.SelectedDate.Value.ToString("MMMM, dd, yyyy", CultureInfo.InvariantCulture);
            }
            if (this.AllowUpdate)
            {
                this.AllowUpdate = false;
                this.calendar.SelectedDates.Clear();
                DateTime startDate = this.StartDatePicker.SelectedDate.Value;
                TimeSpan tempDate = this.EndDatePicker.SelectedDate.Value - startDate;
                for (int i = 0; i < (tempDate.Days + 1); i++)
                {
                    this.calendar.SelectedDates.Add(startDate.AddDays((double) i));
                }
                this.AllowUpdate = true;
            }
        }

        private void OnStoryboardCompleted(object sender, EventArgs e)
        {
            this.RadExpander1.IsExpanded = true;
        }

        protected override void OnTransitionAnimationCompleted(EventArgs e)
        {
            base.OnTransitionAnimationCompleted(e);
        }
    }
}

