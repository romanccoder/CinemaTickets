using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Entities
{
    public class Screen
    {
        public int ScreenId
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

        public virtual ICollection<Hall> Halls
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
