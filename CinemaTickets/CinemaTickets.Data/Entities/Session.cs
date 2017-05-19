using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Date
        {
            get;
            set;
        }

        [Required]
        public virtual Film AssociatedFilm
        {
            get;
            set;
        }

        [Required]
        public virtual Hall AssociatedHall
        {
            get;
            set;
        }

        [Required]
        [Range(1, int.MaxValue)]
        public int Price
        {
            get;
            set;
        }
    }
}
