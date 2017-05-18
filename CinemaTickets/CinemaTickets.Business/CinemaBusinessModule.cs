using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.Business.Services;
using Ninject.Modules;

namespace CinemaTickets.Business
{
    public class CinemaBusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IScreenService>().To<ScreenService>();
        }
    }
}
