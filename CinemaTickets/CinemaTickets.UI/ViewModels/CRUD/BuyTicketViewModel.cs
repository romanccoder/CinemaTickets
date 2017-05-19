using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CinemaTickets.Data;
using DevExpress.Mvvm;
using CinemaTickets.Data.Entities;
using CinemaTickets.UI.Utilities;
using DevExpress.Mvvm.DataAnnotations;

namespace CinemaTickets.UI.ViewModels.CRUD
{
    public class BuyTicketViewModel : EditViewModel<Ticket>
    {
        private CinemaContext _context;

        public BuyTicketViewModel(CinemaContext context)
        {
            _context = context;
            Sessions = new ObservableCollection<Session>();
            SelectedDate = DateTime.Now;
            MinDate = DateTime.Now;
            Model = new Ticket();
            Positions = new ObservableCollection<Position>();
            RefreshSessions();
        }

        private void RefreshSessions()
        {
            var sessions = _context.Sessions.Where(s => DbFunctions.TruncateTime(s.Date) == SelectedDate.Date).ToList();
            Sessions.Clear();

            foreach (var session in sessions)
            {
                Sessions.Add(session);
            }
        }

        public DateTime MinDate
        {
            get { return GetProperty(() => MinDate); }

            set { SetProperty(() => MinDate, value); }
        }

        public DateTime SelectedDate
        {
            get { return GetProperty(() => SelectedDate); }

            set { SetProperty(() => SelectedDate, value); RefreshSessions(); }
        }

        public Session SelectedSession
        {
            get { return GetProperty(() => SelectedSession); }

            set
            {
                SetProperty(() => SelectedSession, value);
                Model.AssociatedSession = value;
                RefreshPlaces();
            }
        }

        public ObservableCollection<Session> Sessions
        {
            get;
            set;
        }

        private void RefreshPlaces()
        {
            Positions.Clear();

            List<Ticket> boughtTickets = _context.Tickets
                .Include(t => t.AssociatedSession)
                .Where(t => t.AssociatedSession.SessionId == Model.AssociatedSession.SessionId && t.LastStatus == TicketStatus.Bought)
                .ToList();

            for (int i = 1; i <= Model.AssociatedSession.AssociatedHall.Rows; i++)
            {
                for (int j = 1; j <= Model.AssociatedSession.AssociatedHall.PlacesPerRow; j++)
                {
                    Positions.Add(new Position(i, j, boughtTickets.Count(t => t.Row == i && t.Place == j) == 1));
                }
            }
        }

        public ObservableCollection<Position> Positions
        {
            get { return GetProperty(() => Positions); }
            set { SetProperty(() => Positions, value); }
        }

        private List<Position> GetSelectedPositions()
        {
            return Positions.Where(p => p.Selected).ToList();
        }

        public IMessageBoxService MessageBoxService
        {
            get { return GetService<IMessageBoxService>(); }
        }

        [Command]
        public void Buy()
        {
            List<Position> positions = GetSelectedPositions();

            if (positions.Count == 0 || SelectedSession == null)
            {
                MessageBoxService.Show("Session or places not selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                foreach (Position position in GetSelectedPositions())
                {
                    _context.Tickets.Add(new Ticket
                    {
                        AssociatedSession = SelectedSession,
                        LastStatus = TicketStatus.Bought,
                        Row = position.Row,
                        Place = position.Place
                    });
                }

                Close();
            }          

            _context.SaveChanges();
        }
    }
}
