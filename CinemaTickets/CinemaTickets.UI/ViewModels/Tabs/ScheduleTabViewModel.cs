using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.UI.ViewModels.Common;

namespace CinemaTickets.UI.ViewModels.Tabs
{
    public class ScheduleTabViewModel : TabItemViewModel
    {
        public ScheduleTabViewModel()
        {
            Caption = "Schedule";
            Icon = new Uri("pack://application:,,,/Images/schedule.png");
        }
    }
}
