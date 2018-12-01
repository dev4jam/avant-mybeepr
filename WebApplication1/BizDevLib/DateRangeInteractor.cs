using System;

namespace BizDaysLib {
    public class DateRangeInteractor {
        public int GetBizDays(DateTime startDate, DateTime endDate) {
            // Exclude starting day
            var fixedStartDate = startDate.AddDays(1);

            // Exclude ending day
            var fixedEndDate = endDate.AddDays(-1);

            // Returns 0 for invalid time intervals
            if (fixedStartDate > fixedEndDate) { return 0; }

            var wholeDays = (endDate - startDate).TotalDays;

            // At least one whole day
            var totalDays = Math.Max(wholeDays, 1.0);

            // Days before till full week
            var daysBeforeFullWeek = (int)fixedStartDate.DayOfWeek;

            // Days after till full week
            var daysTillFullWeek = 6 - (int)fixedEndDate.DayOfWeek;

            // Weekdays per each week
            const double weekdaysPerWeek = 7.0 / 5.0;

            // Days offsets
            var extraDays = new int[] { 0, 0, 1, 2, 3, 4, 5 };

            // Total offsets for days before and after
            var totalOffsets = extraDays[daysBeforeFullWeek] + extraDays[daysTillFullWeek];

            // Number of days in full weeks including start and end dates
            var businessDaysInFullWeeks = (totalDays + daysBeforeFullWeek + daysTillFullWeek);

            // Total business days
            var totalBusinessDays = (int)(businessDaysInFullWeeks / weekdaysPerWeek) - totalOffsets;

            return totalBusinessDays;
        }
    }
}
