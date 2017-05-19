using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.UI.Utilities
{
    public class Position
    {
        public Position(int row, int place, bool isReserved)
        {
            Row = row;
            Place = place;
            NotReserved = !isReserved;
            Selected = false;
        }

        public int Row
        {
            get;
            private set;
        }

        public int Place
        {
            get;
            private set;
        }

        public bool NotReserved
        {
            get;
            private set;
        }

        public bool Selected
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Row + "," + Place;
        }
    }
}
