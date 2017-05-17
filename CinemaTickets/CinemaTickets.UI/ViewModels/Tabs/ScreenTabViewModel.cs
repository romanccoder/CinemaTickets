using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.UI.ViewModels.Common;

namespace CinemaTickets.UI.ViewModels.Tabs
{
    public class ScreenTabViewModel : TabItemViewModel
    {
        public ScreenTabViewModel()
        {
            Caption = "Screens";
            Icon = new Uri("pack://application:,,,/Images/screen.png");
        }
    }
}
