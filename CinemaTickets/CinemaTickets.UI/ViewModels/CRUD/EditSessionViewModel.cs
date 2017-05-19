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
    public class EditSessionViewModel : EditViewModel<Session>
    {

        private CinemaContext _context;

        public EditSessionViewModel(Session session, CinemaContext context)
        {
            SaveCaption = "Save";
            Model = session;
            IsEditing = true;
            _context = context;
            LoadDependencies();
        }

        public EditSessionViewModel(CinemaContext context)
        {
            SaveCaption = "Add";
            Model = new Session();
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

        [Command]
        public void Save()
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
