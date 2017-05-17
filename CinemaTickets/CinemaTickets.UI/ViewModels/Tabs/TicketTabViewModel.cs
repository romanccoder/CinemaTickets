using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.UI.ViewModels.Common;

namespace CinemaTickets.UI.ViewModels.Tabs
{
    public class TicketTabViewModel : TabItemViewModel
    {
        public TicketTabViewModel()
        {
            Caption = "Tickets";
            Icon = new Uri("pack://application:,,,/Images/ticket.png");
        }
    }
}
