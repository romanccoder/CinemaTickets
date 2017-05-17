using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.Data.Entities;

namespace CinemaTickets.Data
{
    public class CinemaContext : DbContext
    {
        public CinemaContext() : base("Cinema")
        {           
        }

        public virtual DbSet<Film> Films
        {
            get;
            set;
        }

        public virtual DbSet<Hall> Halls
        {
            get;
            set;
        }

        public virtual DbSet<Screen> Screens
        {
            get;
            set;
        }

        public virtual DbSet<Session> Sessions
        {
            get;
            set;
        }

        public virtual DbSet<Ticket> Tickets
        {
            get;
            set;
        }

    }
}
