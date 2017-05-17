using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.UI.ViewModels.Common;

namespace CinemaTickets.UI.ViewModels.Tabs
{
    public class FilmTabViewModel : TabItemViewModel
    {
        public FilmTabViewModel()
        {
            Caption = "Films";
            Icon = new Uri("pack://application:,,,/Images/film.png");
        }



    }
}
