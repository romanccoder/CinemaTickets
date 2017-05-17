using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.UI.ViewModels;
using Ninject.Modules;

namespace CinemaTickets.UI
{
    public class TicketsUIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<MainViewModel>().ToSelf();
        }
    }
}
