using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.UI.ViewModels;
using CinemaTickets.UI.ViewModels.Tabs;
using Ninject.Modules;

namespace CinemaTickets.UI
{
    public class CinemaUIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<MainViewModel>().ToSelf();

            // Five main tabs
            Bind<TicketTabViewModel>().ToSelf();
            Bind<FilmTabViewModel>().ToSelf();
            Bind<HallTabViewModel>().ToSelf();
            Bind<ScreenTabViewModel>().ToSelf();
            Bind<ScheduleTabViewModel>().ToSelf();
        }
    }
}
