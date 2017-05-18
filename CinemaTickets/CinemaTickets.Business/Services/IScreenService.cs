using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.Data.Entities;

namespace CinemaTickets.Business.Services
{
    public interface IScreenService
    {
        List<Screen> GetAll();
        bool Remove(int id);
        //void AddOrUpdate(Screen screen);
        //void Save();
    }
}
