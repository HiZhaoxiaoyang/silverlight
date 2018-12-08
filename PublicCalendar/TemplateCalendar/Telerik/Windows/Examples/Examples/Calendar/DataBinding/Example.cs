namespace Telerik.Windows.Examples.Examples.Calendar.DataBinding
{
    using Examples.Calendar.CS.TimeListService;
    using System;
    using System.Collections.Generic;
    using System.Data.Services.Client;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using Telerik.Windows.Controls;
    using Telerik.Windows.QuickStart;

    public class Example : Telerik.Windows.QuickStart.Example
    {
        private bool _contentLoaded;
        internal StackPanel loadingPanel;
        internal TextBlock loadingTextBlock;
        internal RadCalendar radCalendar;
        private DataServiceQuery<TimeList> serviceRequest;

        public Example()
        {
            this.InitializeComponent();
            this.LoadFromService();
        }

        private void ClearSelectedDate()
        {
            if (this.radCalendar.SelectedDates.Count > 0)
            {
                this.radCalendar.SelectedDates.Clear();
            }
        }

        private void GetRequest(IAsyncResult asynck)
        {
            List<TimeList> result = this.serviceRequest.EndExecute(asynck).ToList<TimeList>();
            this.ClearSelectedDate();
            this.loadingPanel.Visibility = Visibility.Collapsed;
            this.loadingTextBlock.Visibility = Visibility.Collapsed;
            foreach (TimeList list in result)
            {
                this.radCalendar.SelectedDates.Add(list.Time);
            }
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (!this._contentLoaded)
            {
                this._contentLoaded = true;
                Application.LoadComponent(this, new Uri("/Examples.Calendar;component/Examples/Calendar/DataBinding/Example.xaml", UriKind.Relative));
                this.loadingTextBlock = (TextBlock) base.FindName("loadingTextBlock");
                this.radCalendar = (RadCalendar) base.FindName("radCalendar");
                this.loadingPanel = (StackPanel) base.FindName("loadingPanel");
            }
        }

        private void LoadFromService()
        {
            TimeListDateService timeService = new TimeListDateService(new Uri("TimeDataService.svc", UriKind.Relative));
            this.serviceRequest = timeService.TimeLists;
            this.serviceRequest.BeginExecute(new AsyncCallback(this.GetRequest), null);
        }
    }
}

