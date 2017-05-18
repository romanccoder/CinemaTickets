using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.Data;
using AutoMapper;
using CinemaTickets.Data.Entities;

namespace CinemaTickets.Business.Services
{
    public class ScreenService : IScreenService
    {
        private CinemaContext _context;

        public ScreenService(CinemaContext context)
        {
            _context = context;
        }

        public List<Screen> GetAll()
        {
            return _context.Screens.ToList();
        }

        public bool Remove(int id)
        {
            Screen screen = _context.Screens.Find(id);

            if (screen != null)
            {
                _context.Screens.Remove(screen);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

    }
}
