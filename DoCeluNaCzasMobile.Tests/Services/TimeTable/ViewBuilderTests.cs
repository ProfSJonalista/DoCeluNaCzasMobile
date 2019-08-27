using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DoCeluNaCzasMobile.Models.TimeTable;
using DoCeluNaCzasMobile.Services.TimeTable;
using NUnit.Framework;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile.Tests.Services.TimeTable
{
    public class ViewBuilderTests
    {
        [Test]
        public void BuildTest()
        {
            var vb = new ViewBuilder();
            var minuteDictionary = GetMinuteDictionary();

            var scrollView = vb.Build(minuteDictionary, DayType.Weekday);

            Assert.NotNull(scrollView);
            Assert.NotNull(scrollView.Content);
        }

        static Dictionary<int, List<int>> GetMinuteDictionary()
        {
            var dictionary = new Dictionary<int, List<int>>();

            for (var hour = 0; hour < 24; hour++)
            {
                if (!dictionary.ContainsKey(hour))
                    dictionary.Add(hour, new List<int>());

                if (hour % 3 == 0)
                {
                    for (var minute = 0; minute < 59; minute += 20)
                    {
                        if (dictionary[hour].Count <= 0)
                            dictionary[hour].Add(minute);
                    }
                }

                if (hour % 5 == 0)
                {
                    for (var minute = 0; minute < 59; minute += 10)
                    {
                        if (dictionary[hour].Count <= 0)
                            dictionary[hour].Add(minute);
                    }
                }
            }

            return dictionary;
        }
    }
}