using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.Data;
using CinemaTickets.Data.Entities;
using DevExpress.Mvvm.DataAnnotations;

namespace CinemaTickets.UI.ViewModels.CRUD
{
    public class EditFilmViewModel : EditViewModel<Film>
    {
        private CinemaContext _context;

        public EditFilmViewModel(Film film, CinemaContext context)
        {
            SaveCaption = "Save";
            Model = film;
            IsEditing = true;
            _context = context;
        }

        public EditFilmViewModel(CinemaContext context)
        {
            SaveCaption = "Add";
            Model = new Film();
            _context = context;
        }

        public ObservableCollection<Film> Films
        {
            get;
            set;
        }

        [Command]
        public void Save()
        {
            if (!IsEditing)
            {
                _context.Films.Add(Model);
            }

            _context.SaveChanges();

            Close();
        }
    }
}
