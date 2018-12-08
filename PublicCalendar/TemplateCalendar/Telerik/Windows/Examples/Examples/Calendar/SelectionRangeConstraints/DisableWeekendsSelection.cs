namespace Telerik.Windows.Examples.Examples.Calendar.SelectionRangeConstraints
{
    using System;
    using System.Windows;
    using Telerik.Windows.Controls;
    using Telerik.Windows.Controls.Calendar;

    public class DisableWeekendsSelection : DataTemplateSelector
    {
        private DataTemplate defaultTemplate;

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            CalendarButtonContent content = item as CalendarButtonContent;
            if ((content != null) && ((((content.Date.DayOfWeek == DayOfWeek.Saturday) || (content.Date.DayOfWeek == DayOfWeek.Sunday)) || (content.Date.Month == DateTime.Now.Month)) || (content.Date.Month == (DateTime.Now.Month + 2))))
            {
                content.IsEnabled = false;
            }
            return this.DefaultTemplate;
        }

        public DataTemplate DefaultTemplate
        {
            get
            {
                return this.defaultTemplate;
            }
            set
            {
                this.defaultTemplate = value;
            }
        }
    }
}

