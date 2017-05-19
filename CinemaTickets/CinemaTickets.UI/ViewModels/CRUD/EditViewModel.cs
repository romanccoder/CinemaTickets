using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.UI.Services;
using DevExpress.Mvvm;

namespace CinemaTickets.UI.ViewModels.CRUD
{
    public class EditViewModel<T> : ViewModelBase, IDataErrorInfo, ISupportClose
    {

        public string this[string columnName]
        {
            get
            {
                Error = IDataErrorInfoHelper.GetErrorText(this, columnName);
                return Error;
            }
            
        }

        public T Model
        {
            get { return GetProperty(() => Model); }
            set { SetProperty(() => Model, value); }
        }

        public string SaveCaption
        {
            get { return GetProperty(() => SaveCaption); }
            set { SetProperty(() => SaveCaption, value); }
        }

        public bool IsEditing
        {
            get;
            set;
        }

        public string Error
        {
            get;
            private set;
        }

        public event Action OnClose;

        protected void Close()
        {
            OnClose();
        }
    }
}
