using System;
using System.Collections.Generic;

namespace BizDaysLib {
    public class DateTimeHolidaysDataSource: IHolidaysDataSource {
        private List<DateTime> holidays;

        public DateTimeHolidaysDataSource() {
            holidays = new List<DateTime>();
        }

        public void Add(DateTime holiday) {
            holidays.Add(holiday);
        }

        public DateTime[] GetHolidays(int year) {
            return holidays.ToArray();
        }
    }
}
