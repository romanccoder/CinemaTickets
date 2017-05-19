using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
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
        [Required]
        public DateTime ReleaseDate
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
