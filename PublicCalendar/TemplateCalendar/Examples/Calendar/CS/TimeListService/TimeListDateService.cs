namespace Examples.Calendar.CS.TimeListService
{
    using System;
    using System.Data.Services.Client;

    public class TimeListDateService : DataServiceContext
    {
        private DataServiceQuery<TimeList> _TimeLists;

        public TimeListDateService(Uri serviceRoot) : base(serviceRoot)
        {
            base.ResolveName = new Func<Type, string>(this.ResolveNameFromType);
            base.ResolveType = new Func<string, Type>(this.ResolveTypeFromName);
        }

        public void AddToTimeLists(TimeList timeList)
        {
            base.AddObject("TimeLists", timeList);
        }

        protected string ResolveNameFromType(Type clientType)
        {
            if (clientType.Namespace.Equals("Examples.Calendar.CS.TimeListService", StringComparison.Ordinal))
            {
                return ("TestProject.Web." + clientType.Name);
            }
            return null;
        }

        protected Type ResolveTypeFromName(string typeName)
        {
            if (typeName.StartsWith("TestProject.Web", StringComparison.Ordinal))
            {
                return base.GetType().Assembly.GetType("Examples.Calendar.CS.TimeListService" + typeName.Substring(15), true);
            }
            return null;
        }

        public DataServiceQuery<TimeList> TimeLists
        {
            get
            {
                if (this._TimeLists == null)
                {
                    this._TimeLists = base.CreateQuery<TimeList>("TimeLists");
                }
                return this._TimeLists;
            }
        }
    }
}

