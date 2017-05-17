using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Entities
{
    public class Film
    {
        public int FilmId
        {
            get;
            set;
        }

        public string Caption
        {
            get;
            set;
        }

        [Column(TypeName = "text")]
        public string Description
        {
            get;
            set;
        }

        [Column(TypeName = "date")]
        public DateTime ReleaseDate
        {
            get;
            set;
        }

        public string ImageName
        {
            get;
            set;
        }

    }
}
