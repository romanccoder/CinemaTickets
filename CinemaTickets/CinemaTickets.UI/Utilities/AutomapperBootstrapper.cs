using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTickets.Business;

namespace CinemaTickets.UI.Utilities
{
    public class AutomapperBootstrapper
    {
        public static void Bootstrap()
        {
            Mapper.Initialize(e =>
            {
                e.AddProfile(new CinemaUIProfile());
                e.AddProfile(new CinemaBusinessProfile());
            });
        }
    }
}
