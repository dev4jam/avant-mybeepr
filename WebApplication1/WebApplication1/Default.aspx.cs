using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizDaysLib;

namespace WebApplication {
    public partial class _Default : Page {
        private IHolidaysDataSource source;
        private IWorkDaysInteractor interactor;

        protected void Page_Load(object sender, EventArgs e) {
            CreateHolidays();

            interactor = new DynamicWorkDaysInteractor();
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
            GenericHolidaysDataSource source = new GenericHolidaysDataSource();

            source.Add(new Holiday(1, 1, true, "New Year"));
            source.Add(new Holiday(26, 1, true, "Australia day"));
            source.Add(new Holiday(30, 3, true, "Good Friday"));
            source.Add(new Holiday(31, 3, true, "Easter"));
            source.Add(new Holiday(25, 4, false, "Anzac Day"));
            source.Add(new Holiday(DayOfWeek.Monday, 1, 6, true, "Queen's Birthday"));
            source.Add(new Holiday(6, 8, true, "Bank Holiday"));
            source.Add(new Holiday(DayOfWeek.Monday, 0, 10, true, "Labor Day"));
            source.Add(new Holiday(25, 12, true, "Christmas"));
            source.Add(new Holiday(26, 12, true, "Boxing Day"));

            this.source = source;
        }

        private int GetBusinessDays(DateTime startDate, DateTime endDate) {
            var businessDays = interactor.GetBizDays(startDate, endDate, source);

            return businessDays;
        }
    }
}