using System;
using System.Collections.Generic;

namespace BizDaysLib {
     public class GenericHolidaysDataSource: IHolidaysDataSource {
        private List<Holiday> holidays;

        public GenericHolidaysDataSource() {
            holidays = new List<Holiday>();
        }

        public void Add(Holiday holiday) {
            holidays.Add(holiday);
        }

        public DateTime[] GetHolidays(int year) {
            List<DateTime> holidayDays = new List<DateTime>();

            foreach (Holiday holiday in holidays) {
                var holidayDate = holiday.GetEventDate(year);

                holidayDays.Add(holidayDate);
            }

            return holidayDays.ToArray();
        }
    }
}
