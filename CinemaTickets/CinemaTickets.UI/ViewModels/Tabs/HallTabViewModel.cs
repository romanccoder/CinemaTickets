using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.UI.ViewModels.Common;

namespace CinemaTickets.UI.ViewModels.Tabs
{
    public class HallTabViewModel : TabItemViewModel
    {
        public HallTabViewModel()
        {
            Caption = "Halls";
            Icon = new Uri("pack://application:,,,/Images/hall.png");
        }
    }
}
