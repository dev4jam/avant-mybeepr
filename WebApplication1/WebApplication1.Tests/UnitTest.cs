using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BizDaysLib;

namespace BizDaysLib.Tests {

    [TestClass]
    public class UnitTest {
        private IHolidaysDataSource source;
        private IWorkDaysInteractor interactor;

        [TestInitialize]
        public void Initialize() {
            interactor = new DynamicWorkDaysInteractor();

            GenericHolidaysDataSource source = new GenericHolidaysDataSource();

            source.Add(new Holiday(1, 1, true, "New Year"));
            source.Add(new Holiday(26, 1, true, "Australia day"));
            source.Add(new Holiday(30, 3, true, "Good Friday"));
            source.Add(new Holiday(31, 3, true, "Easter"));
            source.Add(new Holiday(25, 4, false, "Anzac Day"));
            source.Add(new Holiday(DayOfWeek.Monday, 1, 6, false, "Queen's Birthday"));
            source.Add(new Holiday(6, 8, true, "Bank Holiday"));
            source.Add(new Holiday(DayOfWeek.Monday, 0, 10, true, "Labor Day"));
            source.Add(new Holiday(25, 12, true, "Christmas"));
            source.Add(new Holiday(26, 12, true, "Boxing Day"));

            this.source = source;
        }

        [TestMethod]
        public void TestMethodZeroDays() {
            var startDate = new DateTime(2018, 11, 23);
            var endDate = new DateTime(2018, 11, 26);

            var bizDays = interactor.GetBizDays(startDate, endDate, source);

            Assert.AreEqual(bizDays, 0);

            startDate = new DateTime(2018, 11, 24);
            endDate = new DateTime(2018, 11, 26);

            bizDays = interactor.GetBizDays(startDate, endDate, source);

            Assert.AreEqual(bizDays, 0);

            startDate = new DateTime(2018, 11, 25);
            endDate = new DateTime(2018, 11, 26);

            bizDays = interactor.GetBizDays(startDate, endDate, source);

            Assert.AreEqual(bizDays, 0);

            startDate = new DateTime(2018, 11, 25);
            endDate = new DateTime(2018, 11, 26);

            bizDays = interactor.GetBizDays(startDate, endDate, source);

            Assert.AreEqual(bizDays, 0);

            startDate = new DateTime(2018, 11, 26);
            endDate = new DateTime(2018, 11, 27);

            bizDays = interactor.GetBizDays(startDate, endDate, source);

            Assert.AreEqual(bizDays, 0);
        }

        [TestMethod]
        public void TestMethodNonZeroDays() {
            var startDate = new DateTime(2018, 11, 26);
            var endDate = new DateTime(2018, 11, 28);

            var bizDays = interactor.GetBizDays(startDate, endDate, source);

            Assert.AreEqual(bizDays, 1);

            startDate = new DateTime(2018, 11, 22);
            endDate = new DateTime(2018, 11, 24);

            bizDays = interactor.GetBizDays(startDate, endDate, source);

            Assert.AreEqual(bizDays, 1);

            startDate = new DateTime(2018, 11, 22);
            endDate = new DateTime(2018, 11, 25);

            bizDays = interactor.GetBizDays(startDate, endDate, source);

            Assert.AreEqual(bizDays, 1);

            startDate = new DateTime(2018, 11, 21);
            endDate = new DateTime(2018, 11, 25);

            bizDays = interactor.GetBizDays(startDate, endDate, source);

            Assert.AreEqual(bizDays, 2);

            startDate = new DateTime(2018, 11, 15);
            endDate = new DateTime(2018, 11, 27);

            bizDays = interactor.GetBizDays(startDate, endDate, source);

            Assert.AreEqual(bizDays, 7);

            startDate = new DateTime(2018, 11, 15);
            endDate = new DateTime(2018, 11, 26);

            bizDays = interactor.GetBizDays(startDate, endDate, source);

            Assert.AreEqual(bizDays, 6);
        }

        [TestMethod]
        public void TestMethodDynamicHolidays() {
            var startDate = new DateTime(2018, 6, 11);
            var endDate = new DateTime(2018, 6, 13);

            var bizDays = interactor.GetBizDays(startDate, endDate, source);

            Assert.AreEqual(bizDays, 1);

            startDate = new DateTime(2018, 6, 10);
            endDate = new DateTime(2018, 6, 13);

            bizDays = interactor.GetBizDays(startDate, endDate, source);

            Assert.AreEqual(bizDays, 1);

            startDate = new DateTime(2018, 6, 10);
            endDate = new DateTime(2018, 6, 12);

            bizDays = interactor.GetBizDays(startDate, endDate, source);

            Assert.AreEqual(bizDays, 0);

            startDate = new DateTime(2018, 6, 8);
            endDate = new DateTime(2018, 6, 13);

            bizDays = interactor.GetBizDays(startDate, endDate, source);

            Assert.AreEqual(bizDays, 1);
        }
    }
}
