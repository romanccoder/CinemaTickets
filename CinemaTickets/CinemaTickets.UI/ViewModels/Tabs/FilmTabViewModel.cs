using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.Data;
using CinemaTickets.Data.Entities;
using CinemaTickets.UI.Messages;
using CinemaTickets.UI.Utilities;
using CinemaTickets.UI.ViewModels.Common;
using CinemaTickets.UI.ViewModels.CRUD;
using Ninject.Syntax;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Ninject;
using Ninject.Parameters;

namespace CinemaTickets.UI.ViewModels.Tabs
{
    public class FilmTabViewModel : TabItemViewModel
    {

        private IResolutionRoot _resolutionRoot;
        private CinemaContext _context;

        public FilmTabViewModel(IResolutionRoot resolutionRoot, CinemaContext context)
        {
            Caption = "Films";
            Icon = new Uri("pack://application:,,,/Images/film.png");

            _resolutionRoot = resolutionRoot;
            _context = context;
            Films = new ObservableCollection<Film>();
            Refresh();
        }

        public IDialogService DialogService
        {
            get { return GetService<IDialogService>(); }
        }

        public ObservableCollection<Film> Films
        {
            get { return GetProperty(() => Films); }

            set { SetProperty(() => Films, value); }
        }

        private void Refresh()
        {
            List<Film> films = null;
            // Review OD: It's rather to use ternary operator instead of if-else
            if (!String.IsNullOrEmpty(SearchText))
            {
                films = _context.Films.Where(f => f.Caption.Contains(SearchText)).ToList();
            }
            else
            {
                films = _context.Films.ToList();
            }
            
            Films.Clear();

            foreach (var film in films)
            {
                Films.Add(film);
            }
        }

        public Film SelectedFilm
        {
            get { return GetProperty(() => SelectedFilm); }

            set { SetProperty(() => SelectedFilm, value); }
        }

        public string SearchText
        {
            get { return GetProperty(() => SearchText); }

            set
            {
                SetProperty(() => SearchText, value);
                Refresh();
            }

        }

        public bool CanEdit()
        {
            return SelectedFilm != null;
        }

        [Command]
        public void Add()
        {
            EditFilmViewModel editFilmViewModel = _resolutionRoot.Get<EditFilmViewModel>();
            ((ISupportParentViewModel) editFilmViewModel).ParentViewModel = this;
            DialogService.ShowDialog("Film Editor", editFilmViewModel);
            Refresh();
        }

        [Command]
        public void Edit()
        {
            EditFilmViewModel editFilmViewModel = _resolutionRoot.Get<EditFilmViewModel>(new ConstructorArgument("film", SelectedFilm));
            ((ISupportParentViewModel)editFilmViewModel).ParentViewModel = this;
            DialogService.ShowDialog("Film Editor", editFilmViewModel);
            Refresh();
        }

        public bool CanRemove()
        {
            return SelectedFilm != null;
        }

        [Command]
        public void Remove()
        {
            _context.Films.Remove(SelectedFilm);
            _context.SaveChanges();
            Films.Remove(SelectedFilm);
            Messenger.Default.Send(new RefreshScheduleMessage());
        }

    }
}
