using System;
using DateExtension;

namespace BizDays1 {
    public class DateRangeAndListInteractor {
        public int GetBizDays(DateTime startDate, DateTime endDate, DateTime[] holidays) {
            var interactor = new DateRangeInteractor();
            var totalBizDays = interactor.GetBizDays(startDate, endDate);

            foreach (DateTime holiday in holidays) {
                if (holiday.InRange(startDate, endDate) && holiday.IsWeekday()) {
                    totalBizDays--;
                }
            }

            return totalBizDays;
        }
    }
}
