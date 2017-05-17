using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Entities
{
    public class Session
    {
        public int SessionId
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public virtual Film AssociatedFilm
        {
            get;
            set;
        }

        public virtual Hall AssociatedHall
        {
            get;
            set;
        }
    }
}
