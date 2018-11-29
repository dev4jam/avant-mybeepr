using System;
using DateExtension;

namespace BizDays1 {
    public class Holiday {
        public readonly int dayOfMonth;
        public readonly int month;
        public readonly DayOfWeek dayOfWeek;
        public readonly int weekOfMonth;
        public readonly bool shiftsIfWeekend;

        public Holiday(int dayOfMonth, int month, bool shiftsIfWeekend) {
            if (dayOfMonth < 1 || dayOfMonth > 31) {
                throw new ArgumentException("Value should be between 1 and 31", nameof(dayOfMonth));
            }

            if (month < 1 || month > 12) {
                throw new ArgumentException("Value should be between 1 and 12", nameof(month));
            }

            this.dayOfMonth = dayOfMonth;
            this.month = month;
            this.dayOfWeek = 0;
            this.weekOfMonth = 0;
            this.shiftsIfWeekend = shiftsIfWeekend;
        }

        public Holiday(DayOfWeek dayOfWeek, int weekOfMonth, int month, bool shiftsIfWeekend) {
            if (month < 1 || month > 12) {
                throw new ArgumentException("Value should be between 1 and 12", nameof(month));
            }

            if (weekOfMonth < 0 || weekOfMonth > 3) {
                throw new ArgumentException("Value should be between 0 and 3", nameof(weekOfMonth));
            }

            this.dayOfMonth = 0;
            this.dayOfWeek = dayOfWeek;
            this.weekOfMonth = weekOfMonth;
            this.month = month;
            this.shiftsIfWeekend = shiftsIfWeekend;
        }

        public DateTime GetEventDate(int year) {
            var date = new DateTime();

            if (dayOfMonth == 0) {
                date = new DateTime(year, month, 1);

                var daysOffset = dayOfWeek - date.DayOfWeek;

                if (daysOffset < 0) {
                    daysOffset = 6 + daysOffset + (int)dayOfWeek;
                }

                date = date.AddDays(daysOffset + 7 * weekOfMonth);
            } else {
                date = new DateTime(year, month, dayOfMonth);
            }

            var extraDays = new int[] { 1, 0, 0, 0, 0, 0, 2 };

            if (shiftsIfWeekend && date.IsWeekend()) {
                date = date.AddDays(extraDays[(int)date.DayOfWeek]);
            }

            return date;
        }
    }
}
