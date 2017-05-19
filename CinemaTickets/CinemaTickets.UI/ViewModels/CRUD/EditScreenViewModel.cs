using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CinemaTickets.Data;
using CinemaTickets.Data.Entities;
using CinemaTickets.UI.Utilities;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace CinemaTickets.UI.ViewModels.CRUD
{
    public class EditScreenViewModel : EditViewModel<Screen>
    {
        private CinemaContext _context;

        public EditScreenViewModel(Screen screen, CinemaContext context)
        {
            SaveCaption = "Save";
            Model = screen;
            IsEditing = true;
            _context = context;
        }

        public EditScreenViewModel(CinemaContext context)
        {
            SaveCaption = "Add";
            Model = new Screen();
            _context = context;
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
                    _context.Screens.Add(Model);
                }

                _context.SaveChanges();

                Close();
            }

            
        }
    }
}
