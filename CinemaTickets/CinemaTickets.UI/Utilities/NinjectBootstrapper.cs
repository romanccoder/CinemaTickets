using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.Data;
using CinemaTickets.UI.IoC;
using Ninject;

namespace CinemaTickets.UI.Utilities
{
    public class NinjectBootstrapper
    {
        public static void Bootstrap()
        {
            NinjectHolder.Kernel = new StandardKernel();
            NinjectHolder.Kernel.Load(new CinemaDataModule());
            NinjectHolder.Kernel.Load(new CinemaUIModule());
        }
    }
}
