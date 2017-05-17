using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace CinemaTickets.UI.ViewModels.Common
{
    public class MenuItemViewModel : ViewModelBase
    {
        public MenuItemViewModel(Action executeMethod)
        {
            ExecuteCommand = new DelegateCommand(executeMethod);
        }

        public MenuItemViewModel()
        {
            ExecuteCommand = new DelegateCommand(Execute);
        }

        public string Caption
        {
            get;
            set;
        }

        public Uri Icon
        {
            get;
            set;
        }

        public List<MenuItemViewModel> Children
        {
            get;
            set;
        }

        public ICommand ExecuteCommand
        {
            get;
            set;
        }

        public virtual void Execute()
        {
            
        }

    }
}
