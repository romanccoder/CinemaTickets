using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.Data;
using CinemaTickets.Data.Entities;
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

        [Command]
        public void Save()
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
