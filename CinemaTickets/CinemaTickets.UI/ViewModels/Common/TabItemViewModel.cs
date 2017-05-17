using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace CinemaTickets.UI.ViewModels.Common
{
    public class TabItemViewModel : ViewModelBase
    {
        public virtual string Caption
        {
            get;
            protected set;
        }

        public virtual Uri Icon
        {
            get;
            protected set;
        }

    }
}
