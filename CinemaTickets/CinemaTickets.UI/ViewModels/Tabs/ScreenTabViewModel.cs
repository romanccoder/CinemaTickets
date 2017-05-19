using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using CinemaTickets.Data;
using CinemaTickets.Data.Entities;
using CinemaTickets.UI.Utilities;
using CinemaTickets.UI.ViewModels.Common;
using CinemaTickets.UI.ViewModels.CRUD;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;

namespace CinemaTickets.UI.ViewModels.Tabs
{
    public class ScreenTabViewModel : TabItemViewModel
    {
        private IResolutionRoot _resolutionRoot;
        private CinemaContext _context;

        public ScreenTabViewModel(IResolutionRoot resolutionRoot, CinemaContext context)
        {
            Caption = "Screens";
            Icon = new Uri("pack://application:,,,/Images/screen.png");

            _context = context;
            _resolutionRoot = resolutionRoot;
            Screens = new ObservableCollection<Screen>();
            Refresh();
        }

        public IDialogService DialogService
        {
            get { return GetService<IDialogService>(); }            
        }

        public ObservableCollection<Screen> Screens
        {
            get { return GetProperty(() => Screens); }

            set { SetProperty(() => Screens, value); }
        }

        private void Refresh()
        {
            var screens = _context.Screens.ToList();
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
            EditScreenViewModel editScreenViewModel = _resolutionRoot.Get<EditScreenViewModel>();
            DialogService.ShowDialog("Screen Editor", editScreenViewModel);
            Refresh();
        }

        [Command]
        public void Edit()
        {
            EditScreenViewModel editScreenViewModel = _resolutionRoot.Get<EditScreenViewModel>(new ConstructorArgument("screen", SelectedScreen));
            DialogService.ShowDialog("Screen Editor", editScreenViewModel);
        }

        public bool CanRemove()
        {
            return SelectedScreen != null;
        }

        [Command]
        public void Remove()
        {
            _context.Screens.Remove(SelectedScreen);
            Screens.Remove(SelectedScreen);
        }
    }
}