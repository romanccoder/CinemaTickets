using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CinemaTickets.UI.IoC;
using CinemaTickets.UI.Utilities;
using CinemaTickets.UI.ViewModels;
using Ninject;

namespace CinemaTickets.UI.Controls
{
    /// <summary>
    /// Interaction logic for PlaceControl.xaml
    /// </summary>
    public partial class PlaceControl : UserControl
    {
        public static readonly DependencyProperty RowsProperty = DependencyProperty.Register
        (
            "Rows",
            typeof(int),
            typeof(PlaceControl),
            new PropertyMetadata(1, RowsChangedCallback)
        );

        private static void RowsChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {

        }

        public static readonly DependencyProperty PlacesPerRowProperty = DependencyProperty.Register
        (
            "PlacesPerRow",
            typeof(int),
            typeof(PlaceControl),
            new PropertyMetadata(1)
        );

        public static readonly DependencyProperty ReservedPositionsProperty = DependencyProperty.Register
        (
            "ReservedPositions",
            typeof(ObservableCollection<Position>),
            typeof(PlaceControl),
            new PropertyMetadata(new ObservableCollection<Position>())
        );

        public PlaceControl()
        {
            InitializeComponent();

            MainBorder.DataContext = NinjectHolder.Kernel.Get<PlaceControlViewModel>();
        }

        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }

        public int PlacesPerRow
        {
            get { return (int)GetValue(PlacesPerRowProperty); }
            set { SetValue(PlacesPerRowProperty, value); }
        }

        public ObservableCollection<Position> ReservedPositions
        {
            get { return (ObservableCollection<Position>)GetValue(ReservedPositionsProperty); }
            set { SetValue(ReservedPositionsProperty, value); }
        }


    }
}
