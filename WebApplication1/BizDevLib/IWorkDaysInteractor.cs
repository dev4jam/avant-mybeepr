using System;

namespace BizDaysLib {
    public interface IWorkDaysInteractor {
        int GetBizDays(DateTime startDate, DateTime endDate, IHolidaysDataSource holidaysSource);
    }
}
