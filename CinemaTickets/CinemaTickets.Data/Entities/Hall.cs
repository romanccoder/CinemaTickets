using System;
using System.Collections.Generic;
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

        public string Caption
        {
            get;
            set;
        }

        public int Rows
        {
            get;
            set;
        }

        public int PlacesPerRow
        {
            get;
            set;
        }

        public virtual Screen AssociatedScreen
        {
            get;
            set;
        }
    }
}
