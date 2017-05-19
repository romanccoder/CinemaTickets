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
    public class EditSessionViewModel : EditViewModel<Session>
    {

        private CinemaContext _context;

        public EditSessionViewModel(Session session, CinemaContext context)
        {
            SaveCaption = "Save";
            Model = session;
            MinDate = Model.Date;
            IsEditing = true;
            _context = context;
            LoadDependencies();
        }

        public EditSessionViewModel(CinemaContext context)
        {
            SaveCaption = "Add";
            Model = new Session();
            Model.Date = DateTime.Now;
            MinDate = DateTime.Now;
            _context = context;
            LoadDependencies();
        }

        private void LoadDependencies()
        {
            Films = new ObservableCollection<Film>(_context.Films.ToList());
            Halls = new ObservableCollection<Hall>(_context.Halls.ToList());
        }

        public ObservableCollection<Film> Films
        {
            get;
            set;
        }

        public ObservableCollection<Hall> Halls
        {
            get;
            set;
        }

        public DateTime MinDate
        {
            get;
            private set;
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
                    _context.Sessions.Add(Model);
                }

                _context.SaveChanges();

                Close();
            }
            
        }
    }
}
