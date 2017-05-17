using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Entities
{
    public class Ticket
    {
        public int TicketId
        {
            get;
            set;
        }

        public virtual Session AssociatedSession
        {
            get;
            set;
        }

        public int Row
        {
            get;
            set;
        }

        public int Place
        {
            get;
            set;
        }

        public TicketStatus LastStatus
        {
            get;
            set;
        }
    }
}
