using System;

namespace BizDaysLib {
    public interface IHolidaysDataSource {
        DateTime[] GetHolidays(int year);
    }
}
