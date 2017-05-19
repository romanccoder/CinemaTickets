using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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
            Messenger.Default.Register<RefreshScheduleMessage>(this, (message) => Refresh());
            Refresh();
            MinDate = _context.Sessions.Count() > 0 ?_context.Sessions.Min(s => s.Date) : DateTime.Now;
            SearchDate = MinDate;
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

        public DateTime MinDate
        {
            get;
            set;
        }

        [Command]
        public void Search()
        {
            var sessions = _context.Sessions.Where(s => DbFunctions.TruncateTime(s.Date) == SearchDate).ToList();
            Sessions.Clear();

            foreach (var session in sessions)
            {
                Sessions.Add(session);
            }
        }

        [Command]
        public void Refresh()
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

        public DateTime SearchDate
        {
            get { return GetProperty(() => SearchDate); }

            set
            {
                SetProperty(() => SearchDate, value);
            }

        }

        public bool CanEdit()
        {
            return SelectedSession != null;
        }

        [Command]
        public void Add()
        {
            EditSessionViewModel editSessionViewModel = _resolutionRoot.Get<EditSessionViewModel>();
            ((ISupportParentViewModel)editSessionViewModel).ParentViewModel = this;
            DialogService.ShowDialog("Schedule Editor", editSessionViewModel);
            Refresh();
        }

        [Command]
        public void Edit()
        {
            EditSessionViewModel editSessionViewModel = _resolutionRoot.Get<EditSessionViewModel>(new ConstructorArgument("session", SelectedSession));
            ((ISupportParentViewModel)editSessionViewModel).ParentViewModel = this;
            DialogService.ShowDialog("Film Editor", editSessionViewModel);
            Refresh();
        }

        public bool CanRemove()
        {
            return SelectedSession != null;
        }

        [Command]
        public void Remove()
        {
            _context.Sessions.Remove(SelectedSession);
            _context.SaveChanges();
            Sessions.Remove(SelectedSession);
        }

    }
}
