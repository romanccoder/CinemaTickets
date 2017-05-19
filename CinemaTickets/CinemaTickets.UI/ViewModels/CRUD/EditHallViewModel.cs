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
    public class EditHallViewModel : EditViewModel<Hall>
    {
        private CinemaContext _context;

        public EditHallViewModel(Hall hall, CinemaContext context)
        {
            SaveCaption = "Save";
            Model = hall;
            IsEditing = true;
            _context = context;
            LoadScreens();
        }

        public EditHallViewModel(CinemaContext context)
        {
            SaveCaption = "Add";
            Model = new Hall();
            _context = context;
            LoadScreens();
        }

        private void LoadScreens()
        {
            Screens = new ObservableCollection<Screen>(_context.Screens.ToList());
        }

        public ObservableCollection<Screen> Screens
        {
            get;
            set;
        }

        [Command]
        public void Save()
        {
            if (!IsEditing)
            {
                _context.Halls.Add(Model);
            }

            _context.SaveChanges();

            Close();
        }
    }
}
