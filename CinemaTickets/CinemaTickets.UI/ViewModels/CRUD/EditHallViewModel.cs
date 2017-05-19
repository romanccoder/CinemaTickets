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
                MessageBoxService.Show(ValidatorHelper.GetMessage(messages), "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
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
}
