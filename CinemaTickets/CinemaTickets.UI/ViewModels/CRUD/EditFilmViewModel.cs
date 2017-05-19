using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CinemaTickets.Data;
using CinemaTickets.Data.Entities;
using CinemaTickets.UI.Utilities;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.UI;

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
            Model.ReleaseDate = DateTime.Now;
            _context = context;
        }

        public ObservableCollection<Film> Films
        {
            get;
            set;
        }

        public IMessageBoxService MessageBoxService
        {
            get { return GetService<IMessageBoxService>(); }
        }

        [Command]
        public void Save()
        {
            List<string> messages = new List<string>();
            if (!ValidatorHelper.Validate(Model, messages))
            {
                MessageBoxService.Show(ValidatorHelper.GetMessage(messages), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (!IsEditing)
                {
                    _context.Films.Add(Model);
                }

                _context.SaveChanges();
            }
            

            Close();
        }
    }
}
