using System;

namespace DateExtension {
    public static class DateExtensionClass {
        public static bool IsWeekend(this DateTime date) {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsWeekday(this DateTime date) {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }

        public static bool InRange(this DateTime date, DateTime startDate, DateTime endDate) {
            return startDate < date && date < endDate;
        }

        public static int GetWeekday(this DateTime date) {
            return Convert.ToInt32(date.DayOfWeek);
        }
    }
}
