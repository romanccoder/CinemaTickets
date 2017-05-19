using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public virtual Session AssociatedSession
        {
            get;
            set;
        }

        [Required]
        public int Row
        {
            get;
            set;
        }

        [Required]
        public int Place
        {
            get;
            set;
        }

        [Required]
        public TicketStatus LastStatus
        {
            get;
            set;
        }
    }
}
