using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.UI.ViewModels.Common;
using CinemaTickets.UI.ViewModels.Tabs;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using Ninject;
using Ninject.Syntax;

namespace CinemaTickets.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel(IResolutionRoot root)
        {
            Tabs = new ObservableCollection<TabItemViewModel>();
            InitializeTabs(root);
        }

        private void InitializeTabs(IResolutionRoot root)
        {
            // Tickets tab
            TicketTabViewModel ticketTabViewModel = root.Get<TicketTabViewModel>();
            ((ISupportParentViewModel)ticketTabViewModel).ParentViewModel = this;
            Tabs.Add(ticketTabViewModel);

            // Schedule tab
            ScheduleTabViewModel scheduleTabViewModel = root.Get<ScheduleTabViewModel>();
            ((ISupportParentViewModel)scheduleTabViewModel).ParentViewModel = this;
            Tabs.Add(scheduleTabViewModel);

            // Films tab
            FilmTabViewModel filmTabViewModel = root.Get<FilmTabViewModel>();
            ((ISupportParentViewModel)filmTabViewModel).ParentViewModel = this;
            Tabs.Add(filmTabViewModel);

            // Halls tab
            HallTabViewModel hallTabViewModel = root.Get<HallTabViewModel>();
            ((ISupportParentViewModel)hallTabViewModel).ParentViewModel = this;
            Tabs.Add(hallTabViewModel);

            // Screens tab
            ScreenTabViewModel screenTabViewModel = root.Get<ScreenTabViewModel>();
            ((ISupportParentViewModel)screenTabViewModel).ParentViewModel = this;
            Tabs.Add(screenTabViewModel);
        }

        public ObservableCollection<TabItemViewModel> Tabs
        {
            get { return GetProperty(() => Tabs); }

            private set { SetProperty(() => Tabs, value); }
        }
    }
}
