using DoCeluNaCzasMobile.Views.MainPage;
using System;

namespace DoCeluNaCzasMobile.Models.MainPage
{

    public class MainMasterPageMenuItem
    {
        public MainMasterPageMenuItem()
        {
            TargetType = typeof(MainMasterPageDetail);
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}