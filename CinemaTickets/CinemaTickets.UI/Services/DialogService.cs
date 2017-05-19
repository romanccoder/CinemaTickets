using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;

namespace CinemaTickets.UI.Services
{
    public class DialogService : ViewServiceBase, IDialogService
    {
        public UICommand ShowDialog(IEnumerable<UICommand> dialogCommands, string title, string documentType, object viewModel, object parameter,
            object parentViewModel)
        {
            Window window = new Window();

            if (viewModel is ISupportClose)
            {
                ((ISupportClose) viewModel).OnClose += window.Close;
            }

            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.Title = title;
            window.Content = viewModel;
            window.ShowDialog();

            return new UICommand();
        }
    }
}
