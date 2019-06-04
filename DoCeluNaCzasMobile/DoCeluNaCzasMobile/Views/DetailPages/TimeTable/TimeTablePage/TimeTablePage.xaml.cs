﻿using DoCeluNaCzasMobile.Models.TimeTable;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.TimeTable.TimeTablePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeTablePage : TabbedPage
    {
        public TimeTablePage()
        {
            InitializeComponent();
        }

        public TimeTablePage(MinuteTimeTable minuteTimeTable)
        {
            InitializeComponent();

            WeekdayPageTab.BindingContext = minuteTimeTable.ModMinuteDictionary[DayType.Weekday];
            SaturdayPageTab.BindingContext = minuteTimeTable.ModMinuteDictionary[DayType.Saturday];
            SundayPageTab.BindingContext = minuteTimeTable.ModMinuteDictionary[DayType.Sunday];
        }
    }
}