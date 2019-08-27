using DoCeluNaCzasMobile.Models.TimeTable;
using DoCeluNaCzasMobile.Services.TimeTable.Helpers;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile.Services.TimeTable
{
    public class ViewBuilder
    {
        public ScrollView Build(Dictionary<int, List<int>> minuteDictionary, DayType dayType)
        {
            var grid = new Grid { Margin = 20 };

            CreateColumns(grid, minuteDictionary);
            CreateRows(grid);
            InsertData(grid, minuteDictionary, dayType);

            return new ScrollView { Content = grid };
        }

        static void CreateColumns(Grid grid, Dictionary<int, List<int>> minuteDictionary)
        {
            //oblicza ilość potrzebnych kolumn na minuty, po czym dodaje jeszcze jedną na kolumnę z godzinami
            var numberOfColumnsNeeded = minuteDictionary.Aggregate((l, r) => l.Value.Count > r.Value.Count ? l : r).Value.Count + 1;

            for (var i = 0; i < numberOfColumnsNeeded; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }
        }

        static void CreateRows(Grid grid)
        {
            for (var i = 0; i < 24; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            }
        }

        static void InsertData(Grid grid, Dictionary<int, List<int>> minuteDictionary, DayType dayType)
        {
            var dh = new DateHelper();
            var nearestTime = dh.GetNearestTime(minuteDictionary);
            var isMarked = false;
            var currentDayType = dh.GetCurrentDayType();


            foreach (var item in minuteDictionary)
            {
                var hour = item.Key;
                var minuteList = item.Value;
                var hourLabel = new Label { Text = PadLeft(hour.ToString()) };

                grid.Children.Add(hourLabel, 0, hour);

                foreach (var minute in minuteList)
                {
                    var text = PadLeft(minute.ToString());
                    var minuteLabel = new Label { Text = text };

                    if (hour == nearestTime.Hours && minute == nearestTime.Minutes && !isMarked && currentDayType == dayType)
                    {
                        minuteLabel.TextColor = Color.Red;
                        isMarked = true;
                    }

                    grid.Children.Add(minuteLabel, minuteList.IndexOf(minute) + 1, hour);
                }
            }
        }

        static string PadLeft(string textToPad)
        {
            return textToPad.PadLeft(2, '0') + "     "; //5 spaces
        }
    }
}
