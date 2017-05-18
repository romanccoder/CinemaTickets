using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using CinemaTickets.Business.Services;
using CinemaTickets.Data;
using CinemaTickets.Data.Entities;
using CinemaTickets.UI.ViewModels.Common;
using DevExpress.Mvvm.DataAnnotations;

namespace CinemaTickets.UI.ViewModels.Tabs
{
    public class ScreenTabViewModel : TabItemViewModel
    {
        private IScreenService _screenService;

        public ScreenTabViewModel(ScreenService screenService)
        {
            Caption = "Screens";
            Icon = new Uri("pack://application:,,,/Images/screen.png");

            _screenService = screenService;
            Screens = new ObservableCollection<Screen>();
            Refresh();
        }

        public ObservableCollection<Screen> Screens
        {
            get { return GetProperty(() => Screens); }

            set { SetProperty(() => Screens, value); }
        }

        private void Refresh()
        {
            var screens = _screenService.GetAll();
            Screens.Clear();

            foreach (var screen in screens)
            {
                Screens.Add(screen);
            }
        }

        public Screen SelectedScreen
        {
            get { return GetProperty(() => SelectedScreen); }

            set { SetProperty(() => SelectedScreen, value); }
        }

        public bool CanEdit()
        {
            return SelectedScreen != null;
        }

        [Command]
        public void Add()
        {
            //ScreenDto dto = new ScreenDto() {Caption = "New screen"};
            //Screens.Add(dto);
            //SelectedScreen = dto;
        }

        [Command]
        public void Edit()
        {
            
        }

        public bool CanRemove()
        {
            return SelectedScreen != null;
        }

        [Command]
        public void Remove()
        {
            if (_screenService.Remove(SelectedScreen.ScreenId))
            {
                Screens.Remove(SelectedScreen);
            }
        }
    }
}