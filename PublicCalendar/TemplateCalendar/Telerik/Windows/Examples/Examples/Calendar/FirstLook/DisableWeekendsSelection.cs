namespace Telerik.Windows.Examples.Examples.Calendar.FirstLook
{
    using System;
    using System.Windows;
    using Telerik.Windows.Controls;
    using Telerik.Windows.Controls.Calendar;

    public class DisableWeekendsSelection : DataTemplateSelector
    {
        private DataTemplate defaultTemplate;
        private DataTemplate specialDay;

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            CalendarButtonContent content = item as CalendarButtonContent;
            if ((content != null) && ((content.Date.DayOfWeek == DayOfWeek.Saturday) || (content.Date.DayOfWeek == DayOfWeek.Sunday)))
            {
                content.IsEnabled = false;
            }
            if (((content.Date.Day % 11) == 0) && (content.ButtonType == CalendarButtonType.Date))
            {
                return this.SpecialDay;
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

        public DataTemplate SpecialDay
        {
            get
            {
                return this.specialDay;
            }
            set
            {
                this.specialDay = value;
            }
        }
    }
}

