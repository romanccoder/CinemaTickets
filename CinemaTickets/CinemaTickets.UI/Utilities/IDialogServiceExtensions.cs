using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace CinemaTickets.UI.Utilities
{
    // Review OD: Class name doesn't match naming conventions
    public static class IDialogServiceExtensions
    {
        public static UICommand ShowDialog(this IDialogService service, string title, object viewModel)
        {
            return service.ShowDialog(null, title, null, viewModel, null, null);
        }
    }
}
