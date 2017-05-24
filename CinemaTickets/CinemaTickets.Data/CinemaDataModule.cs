// Review OD: There are some unnecessary usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace CinemaTickets.Data
{
    public class CinemaDataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<CinemaContext>().ToSelf().InThreadScope();
        }
    }
}
