using System;
using System.Collections.Generic;
using System.Linq;
using DoCeluNaCzasMobile.Models.TimeTable;
using DoCeluNaCzasMobile.Services.TimeTable;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.TimeTable.TimeTablePage.Days
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HourAndMinuteGridView : ContentView
    {
        public HourAndMinuteGridView(Dictionary<int, List<int>> minuteDictionary, DayType dayType)
        {
            InitializeComponent();

            var vb = new ViewBuilder();
            Content = vb.Build(minuteDictionary, dayType);
        }
    }
}