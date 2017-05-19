using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.UI.Utilities;
using DevExpress.Mvvm;

namespace CinemaTickets.UI.ViewModels
{
    public class PlaceControlViewModel : ViewModelBase
    {
        public PlaceControlViewModel()
        {
            Positions = new ObservableCollection<Position>();
        }

        private void RefreshPlaces()
        {
            Positions.Clear();

            for (int i = 1; i <= Rows; i++)
            {
                for (int j = 1; j <= PlacesPerRow; j++)
                {
                    Positions.Add(new Position(i, j, true));
                }
            }
        }

        public int Rows
        {
            get { return GetProperty(() => Rows); }
            set { SetProperty(() => Rows, value); RefreshPlaces(); }
        }

        public int PlacesPerRow
        {
            get { return GetProperty(() => PlacesPerRow); }
            set { SetProperty(() => PlacesPerRow, value); RefreshPlaces(); }
        }

        public ObservableCollection<Position> Positions
        {
            get { return GetProperty(() => Positions); }
            set { SetProperty(() => Positions, value); }
        }
    }
}
