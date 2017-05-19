using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.Data;
using CinemaTickets.Data.Entities;
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
    public class ScheduleTabViewModel : TabItemViewModel
    {

        private IResolutionRoot _resolutionRoot;
        private CinemaContext _context;

        public ScheduleTabViewModel(IResolutionRoot resolutionRoot, CinemaContext context)
        {
            Caption = "Schedule";
            Icon = new Uri("pack://application:,,,/Images/schedule.png");

            _resolutionRoot = resolutionRoot;
            _context = context;
            Sessions = new ObservableCollection<Session>();
            Refresh();
        }

        public IDialogService DialogService
        {
            get { return GetService<IDialogService>(); }
        }

        public ObservableCollection<Session> Sessions
        {
            get { return GetProperty(() => Sessions); }

            set { SetProperty(() => Sessions, value); }
        }

        private void Refresh()
        {
            var sessions = _context.Sessions.ToList();
            Sessions.Clear();

            foreach (var session in sessions)
            {
                Sessions.Add(session);
            }
        }

        public Session SelectedSession
        {
            get { return GetProperty(() => SelectedSession); }

            set { SetProperty(() => SelectedSession, value); }
        }

        public bool CanEdit()
        {
            return SelectedSession != null;
        }

        [Command]
        public void Add()
        {
            EditSessionViewModel editSessionViewModel = _resolutionRoot.Get<EditSessionViewModel>();
            DialogService.ShowDialog("Schedule Editor", editSessionViewModel);
            Refresh();
        }

        [Command]
        public void Edit()
        {
            EditSessionViewModel editSessionViewModel = _resolutionRoot.Get<EditSessionViewModel>(new ConstructorArgument("session", SelectedSession));
            DialogService.ShowDialog("Film Editor", editSessionViewModel);
        }

        public bool CanRemove()
        {
            return SelectedSession != null;
        }

        [Command]
        public void Remove()
        {
            _context.Sessions.Remove(SelectedSession);
            Sessions.Remove(SelectedSession);
        }

    }
}
