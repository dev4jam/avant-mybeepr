using System;
using System.Collections.Generic;

namespace BizDaysLib {
    public class DynamicWorkDaysInteractor {
        public int GetBizDays(DateTime startDate, DateTime endDate, Holiday[] holidays) {
            List<DateTime> holidayDays = new List<DateTime>();

            foreach (Holiday calEvent in holidays) {
                var holidayDate = calEvent.GetEventDate(startDate.Year);

                holidayDays.Add(holidayDate);

                if (startDate.Year == endDate.Year) { continue; }

                holidayDate = calEvent.GetEventDate(endDate.Year);

                holidayDays.Add(holidayDate);
            }

            var interactor = new DateRangeAndListInteractor();
            var totalBizDays = interactor.GetBizDays(startDate, endDate, holidayDays.ToArray());

            return totalBizDays;
        }
    }
}