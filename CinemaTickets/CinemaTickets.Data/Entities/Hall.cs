using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Entities
{
    public class Hall
    {
        public int HallId
        {
            get;
            set;
        }

        [Required]
        public string Caption
        {
            get;
            set;
        }

        [Required]
        public int Rows
        {
            get;
            set;
        }

        [Required]
        public int PlacesPerRow
        {
            get;
            set;
        }

        [Required]
        public virtual Screen AssociatedScreen
        {
            get;
            set;
        }


        public override string ToString()
        {
            return Caption;
        }
    }
}
