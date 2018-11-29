using System;

namespace BizDays1
{
    class Program
    {
        static void Main(string[] args)
        {
            var interactor = new DateRangeInteractor();
            var startDate = new DateTime(2018, 11, 23);
            var endDate = new DateTime(2018, 11, 26);

            var bizDays = interactor.GetBizDays(startDate, endDate);

            Console.WriteLine("Should be: 0");
            Console.WriteLine(bizDays);

            startDate = new DateTime(2018, 11, 24);
            endDate = new DateTime(2018, 11, 26);

            bizDays = interactor.GetBizDays(startDate, endDate);

            Console.WriteLine("Should be: 0");
            Console.WriteLine(bizDays);

            startDate = new DateTime(2018, 11, 25);
            endDate = new DateTime(2018, 11, 26);

            bizDays = interactor.GetBizDays(startDate, endDate);

            Console.WriteLine("Should be: 0");
            Console.WriteLine(bizDays);

            startDate = new DateTime(2018, 11, 26);
            endDate = new DateTime(2018, 11, 27);

            bizDays = interactor.GetBizDays(startDate, endDate);

            Console.WriteLine("Should be: 0");
            Console.WriteLine(bizDays);

            startDate = new DateTime(2018, 11, 26);
            endDate = new DateTime(2018, 11, 28);

            bizDays = interactor.GetBizDays(startDate, endDate);

            Console.WriteLine("Should be: 1");
            Console.WriteLine(bizDays);

            startDate = new DateTime(2018, 11, 22);
            endDate = new DateTime(2018, 11, 24);

            bizDays = interactor.GetBizDays(startDate, endDate);

            Console.WriteLine("Should be: 1");
            Console.WriteLine(bizDays);

            startDate = new DateTime(2018, 11, 22);
            endDate = new DateTime(2018, 11, 25);

            bizDays = interactor.GetBizDays(startDate, endDate);

            Console.WriteLine("Should be: 1");
            Console.WriteLine(bizDays);

            startDate = new DateTime(2018, 11, 21);
            endDate = new DateTime(2018, 11, 25);

            bizDays = interactor.GetBizDays(startDate, endDate);

            Console.WriteLine("Should be: 2");
            Console.WriteLine(bizDays);

            startDate = new DateTime(2018, 11, 15);
            endDate = new DateTime(2018, 11, 27);

            bizDays = interactor.GetBizDays(startDate, endDate);

            Console.WriteLine("Should be: 7");
            Console.WriteLine(bizDays);

            startDate = new DateTime(2018, 11, 15);
            endDate = new DateTime(2018, 11, 26);

            bizDays = interactor.GetBizDays(startDate, endDate);

            Console.WriteLine("Should be: 6");
            Console.WriteLine(bizDays);

            var dynamicInteractor = new DynamicWorkDaysInteractor();
            var holiday = new Holiday(DayOfWeek.Monday, 1, 6, true);
            var holidays = new Holiday[] { holiday };

            startDate = new DateTime(2018, 6, 8);
            endDate = new DateTime(2018, 6, 15);

            bizDays = dynamicInteractor.GetBizDays(startDate, endDate, holidays);

            Console.WriteLine("Should be: 3");
            Console.WriteLine(bizDays);
        }
    }
}
