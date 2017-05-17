using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace CinemaTickets.UI.IoC
{
    public class NinjectHolder
    {
        public static IKernel Kernel
        {
            get;
            set;
        }
    }
}
