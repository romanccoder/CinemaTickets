using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CinemaTickets.Data;
using CinemaTickets.Data.Entities;
using CinemaTickets.UI.Messages;
using CinemaTickets.UI.Utilities;
using CinemaTickets.UI.ViewModels.Common;
using CinemaTickets.UI.ViewModels.CRUD;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Ninject;
using Ninject.Syntax;

namespace CinemaTickets.UI.ViewModels.Tabs
{
    public class TicketTabViewModel : TabItemViewModel
    {
        private IResolutionRoot _resolutionRoot;
        private CinemaContext _context;

        public TicketTabViewModel(IResolutionRoot resolutionRoot, CinemaContext context)
        {
            Caption = "Tickets";
            Icon = new Uri("pack://application:,,,/Images/ticket.png");

            _resolutionRoot = resolutionRoot;
            _context = context;
            Tickets = new ObservableCollection<Ticket>();
            Messenger.Default.Register<RefreshHallsMessage>(this, (message) => Refresh());
            Refresh();
        }

        public IDialogService DialogService
        {
            get { return GetService<IDialogService>(); }
        }

        public ObservableCollection<Ticket> Tickets
        {
            get { return GetProperty(() => Tickets); }

            set { SetProperty(() => Tickets, value); }
        }

        public IMessageBoxService MessageBoxService
        {
            get { return GetService<IMessageBoxService>(); }
        }

        private void Refresh()
        {
            Tickets.Clear();

            if (!String.IsNullOrEmpty(SearchId))
            {
                try
                {
                    Ticket ticket = _context.Tickets.Find(Convert.ToInt32(SearchId));

                    if (ticket != null)
                    {
                        Tickets.Add(ticket);
                    }
                }
                catch (FormatException)
                {
                    MessageBoxService.Show("Bad id format", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
            else
            {
                var tickets = _context.Tickets.ToList();

                foreach (var ticket in tickets)
                {
                    Tickets.Add(ticket);
                }
            }
        }

        public Ticket SelectedTicket
        {
            get { return GetProperty(() => SelectedTicket); }

            set { SetProperty(() => SelectedTicket, value); }
        }

        [Command]
        public void BuyTicket()
        {
            BuyTicketViewModel buyTicketViewModel = _resolutionRoot.Get<BuyTicketViewModel>();
            ((ISupportParentViewModel) buyTicketViewModel).ParentViewModel = this;
            DialogService.ShowDialog("Fast-sale System", buyTicketViewModel);
            Refresh();
        }

        public bool CanReturnTicket()
        {
            return SelectedTicket != null && SelectedTicket.LastStatus != TicketStatus.Returned;
        }

        [Command]
        public void ReturnTicket()
        {
            SelectedTicket.LastStatus = TicketStatus.Returned;
            _context.SaveChanges();
            Refresh();
        }

        public string SearchId
        {
            get { return GetProperty(() => SearchId); }

            set { SetProperty(() => SearchId, value); Refresh(); }
        }

        [Command]
        public void Scan()
        {
            MessageBoxService.Show("This button simulates scan, in real case it will be qr code scanner.",
                "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            SearchId = "12345";
        }

    }
}
