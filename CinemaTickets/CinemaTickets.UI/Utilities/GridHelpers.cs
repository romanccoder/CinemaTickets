using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CinemaTickets.UI.Utilities
{
    public class GridHelpers
    {
        public static readonly DependencyProperty RowCountProperty = DependencyProperty.RegisterAttached
        (
            "RowCount",
            typeof(int),
            typeof(GridHelpers),
            new FrameworkPropertyMetadata(OnRowCountChanged)
        );

        public static readonly DependencyProperty ColumnCountProperty = DependencyProperty.RegisterAttached
        (
            "ColumnCount",
            typeof(int),
            typeof(GridHelpers),
            new FrameworkPropertyMetadata(OnColumnCountChanged)
        );

        public static void SetRowCount(DependencyObject element, bool value)
        {
            element.SetValue(RowCountProperty, value);
        }

        public static int GetRowCount(DependencyObject element)
        {
            return (int)element.GetValue(RowCountProperty);
        }

        public static void SetColumnCount(DependencyObject element, bool value)
        {
            element.SetValue(ColumnCountProperty, value);
        }

        public static int GetColumnCount(DependencyObject element)
        {
            return (int)element.GetValue(ColumnCountProperty);
        }

        private static void OnRowCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Grid grid = d as Grid;

            grid.RowDefinitions.Clear();

            for (int i = 0; i <= (int)e.NewValue; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
        }

        private static void OnColumnCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Grid grid = d as Grid;

            grid.ColumnDefinitions.Clear();

            for (int i = 0; i <= (int)e.NewValue; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
    }
}
