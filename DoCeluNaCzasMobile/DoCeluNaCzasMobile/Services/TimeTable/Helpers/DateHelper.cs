using DoCeluNaCzasMobile.Models.TimeTable;
using PublicHoliday;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoCeluNaCzasMobile.Services.TimeTable.Helpers
{
    public class DateHelper
    {
        public DayType GetCurrentDayType()
        {
            var polandPublicHoliday = new PolandPublicHoliday();

            if (polandPublicHoliday.IsPublicHoliday(DateTime.Now) || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                return DayType.Sunday;

            return DateTime.Now.DayOfWeek == DayOfWeek.Saturday
                ? DayType.Saturday
                : DayType.Weekday;
        }

        public TimeSpan GetNearestTime(Dictionary<int, List<int>> minuteDictionary)
        {
            var dtList = new List<TimeSpan>();

            foreach (var item in minuteDictionary)
            {
                foreach (var minute in item.Value)
                {
                    var dtToAdd = new TimeSpan(item.Key, minute, 0);
                    dtList.Add(dtToAdd);
                }
            }

            var filteredDtList = dtList.Where(time => time >= DateTime.Now.TimeOfDay).ToList();

            return filteredDtList.FirstOrDefault();
        }
    }
}
