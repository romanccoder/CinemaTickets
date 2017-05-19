using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.UI.ViewModels.Common;
using Ninject.Syntax;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using CinemaTickets.Data;
using CinemaTickets.Data.Entities;
using CinemaTickets.UI.Messages;
using CinemaTickets.UI.Utilities;
using CinemaTickets.UI.ViewModels.CRUD;
using DevExpress.Mvvm.DataAnnotations;
using Ninject;
using Ninject.Parameters;

namespace CinemaTickets.UI.ViewModels.Tabs
{
    public class HallTabViewModel : TabItemViewModel
    {
        private IResolutionRoot _resolutionRoot;
        private CinemaContext _context;

        public HallTabViewModel(IResolutionRoot resolutionRoot, CinemaContext context)
        {
            Caption = "Halls";
            Icon = new Uri("pack://application:,,,/Images/hall.png");

            _resolutionRoot = resolutionRoot;
            _context = context;
            Halls = new ObservableCollection<Hall>();
            Messenger.Default.Register<RefreshHallsMessage>(this, (message) => Refresh());
            Refresh();
        }

        public IDialogService DialogService
        {
            get { return GetService<IDialogService>(); }
        }

        public ObservableCollection<Hall> Halls
        {
            get { return GetProperty(() => Halls); }

            set { SetProperty(() => Halls, value); }
        }

        private void Refresh()
        {
            var halls = _context.Halls.ToList();
            Halls.Clear();

            foreach (var hall in halls)
            {
                Halls.Add(hall);
            }
        }

        public Hall SelectedHall
        {
            get { return GetProperty(() => SelectedHall); }

            set { SetProperty(() => SelectedHall, value); }
        }

        public bool CanEdit()
        {
            return SelectedHall != null;
        }

        [Command]
        public void Add()
        {
            EditHallViewModel editHallViewModel = _resolutionRoot.Get<EditHallViewModel>();
            ((ISupportParentViewModel) editHallViewModel).ParentViewModel = this;
            DialogService.ShowDialog("Hall Editor", editHallViewModel);
            Refresh();
        }

        [Command]
        public void Edit()
        {
            EditHallViewModel editHallViewModel = _resolutionRoot.Get<EditHallViewModel>(new ConstructorArgument("hall", SelectedHall));
            ((ISupportParentViewModel)editHallViewModel).ParentViewModel = this;
            DialogService.ShowDialog("Hall Editor", editHallViewModel);
            Refresh();
        }

        public bool CanRemove()
        {
            return SelectedHall != null;
        }

        [Command]
        public void Remove()
        {
            _context.Halls.Remove(SelectedHall);
            _context.SaveChanges();
            Halls.Remove(SelectedHall);
            Messenger.Default.Send(new RefreshScheduleMessage());
        }
    }
}
