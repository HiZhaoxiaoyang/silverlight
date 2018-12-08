namespace Examples.Calendar.CS.TimeListService
{
    using System;
    using System.Data.Services.Common;

    [DataServiceKey("ID")]
    public class TimeList
    {
        private int _ID;
        private bool _IsSpecialDay;
        private DateTime _Time;

        public static TimeList CreateTimeList(int ID, DateTime time, bool isSpecialDay)
        {
            TimeList timeList = new TimeList();
            timeList.ID = ID;
            timeList.Time = time;
            timeList.IsSpecialDay = isSpecialDay;
            return timeList;
        }

        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }

        public bool IsSpecialDay
        {
            get
            {
                return this._IsSpecialDay;
            }
            set
            {
                this._IsSpecialDay = value;
            }
        }

        public DateTime Time
        {
            get
            {
                return this._Time;
            }
            set
            {
                this._Time = value;
            }
        }
    }
}

