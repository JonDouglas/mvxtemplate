using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;

namespace MvxTemplate.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        protected BaseViewModel(IMvxMessenger messenger)
        {
            Messenger = messenger;

//            IsLoading = !this.HasAttribute<DoesNotRequireLoadingAttribute>();
        }

        public IMvxMessenger Messenger { get; private set; }
        public event EventHandler LoadingComplete;

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            private set { _isLoading = value; RaisePropertyChanged(() => IsLoading); }
        }

        protected void FinishedLoading(bool successful)
        {
            IsLoading = false;

            if (LoadingComplete != null)
                LoadingComplete.Invoke(this, EventArgs.Empty);
        }

    }
}
