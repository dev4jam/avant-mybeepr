using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizDaysLib;

namespace WebApplication {
    public partial class _Default : Page {
        private Holiday[] holidays;

        protected void Page_Load(object sender, EventArgs e) {
            CreateHolidays();
        }

        protected void OnStartDateSelectionChanged(object sender, EventArgs e) {
            Console.WriteLine(StartDatePicker.SelectedDate.ToLongDateString());
        }

        protected void OnEndDateSelectionChanged(object sender, EventArgs e) {
            Console.WriteLine(EndDatePicker.SelectedDate.ToLongDateString());
        }

        protected void OnActionButtonClick(object sender, EventArgs e) {
            var businessDays = GetBusinessDays(StartDatePicker.SelectedDate, EndDatePicker.SelectedDate);

            ResultLabel.Text = String.Format("Total business days from {0} till {1} is {2}",
                                             StartDatePicker.SelectedDate.ToShortDateString(),
                                             EndDatePicker.SelectedDate.ToShortDateString(),
                                             businessDays);
        }

        private void CreateHolidays() {
            var newHolidays = new List<Holiday>();

            newHolidays.Add(new Holiday(1, 1, true, "New Year"));
            newHolidays.Add(new Holiday(26, 1, true, "Australia day"));
            newHolidays.Add(new Holiday(30, 3, true, "Good Friday"));
            newHolidays.Add(new Holiday(31, 3, true, "Easter"));
            newHolidays.Add(new Holiday(25, 4, false, "Anzac Day"));
            newHolidays.Add(new Holiday(DayOfWeek.Monday, 1, 6, true, "Queen's Birthday"));
            newHolidays.Add(new Holiday(6, 8, true, "Bank Holiday"));
            newHolidays.Add(new Holiday(DayOfWeek.Monday, 0, 10, true, "Labor Day"));
            newHolidays.Add(new Holiday(25, 12, true, "Christmas"));
            newHolidays.Add(new Holiday(26, 12, true, "Boxing Day"));

            holidays = newHolidays.ToArray();
        }

        private int GetBusinessDays(DateTime startDate, DateTime endDate) {
            var interactor = new DynamicWorkDaysInteractor();
            var businessDays = interactor.GetBizDays(startDate, endDate, holidays);

            return businessDays;
        }
    }
}