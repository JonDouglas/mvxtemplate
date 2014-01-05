using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;

namespace MvxTemplate.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
//        public MenuViewModel(IMvxMessenger messenger)
//            : base(messenger)
//        {
//        }

        public MenuViewModel()
        {
            
        }

        private MvxCommand _ShowFirstCommand;
        public MvxCommand ShowFirstCommand
        {
            get
            {
                _ShowFirstCommand = _ShowFirstCommand ?? new MvxCommand(DoStuff);
                return _ShowFirstCommand;
            }
        }

        private void DoStuff()
        {
            ShowViewModel<FirstViewModel>();
        }

    }
}
