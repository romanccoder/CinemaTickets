using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.UI.ViewModels.Common;
using CinemaTickets.UI.ViewModels.Tabs;
using DevExpress.Mvvm;
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
            Tabs.Add(root.Get<TicketTabViewModel>());
            Tabs.Add(root.Get<ScheduleTabViewModel>());
            Tabs.Add(root.Get<FilmTabViewModel>());
            Tabs.Add(root.Get<ScreenTabViewModel>());
            Tabs.Add(root.Get<HallTabViewModel>());
        }

        public ObservableCollection<TabItemViewModel> Tabs
        {
            get { return GetProperty(() => Tabs); }

            private set { SetProperty(() => Tabs, value); }
        }
    }
}
