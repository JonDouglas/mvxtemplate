using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Fragging;
using LegacyBar.Library.BarActions;
using MvxTemplate.Android.Views.Fragments;
using MvxTemplate.Core.ViewModels;
using SlidingMenuSharp;

namespace MvxTemplate.Android.Views.Base
{
    public abstract class ActivityBase : MvxFragmentActivity
    {
        private SlidingMenu _slidingMenu;

        protected virtual ICommand RefreshCommand
        {
            get { return null; }
        }

        protected virtual bool DisableMenuSwipe
        {
            get { return false; }
        }

        protected LegacyBar.Library.Bar.LegacyBar LegacyBar { get; private set; }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

//            ((ViewModelBase)ViewModel).BindLoadingMessage(this, vm => vm.IsLoading, "Loading...");
        }

        public override void SetContentView(int layoutResId)
        {
            base.SetContentView(layoutResId);

            LegacyBar = FindViewById<LegacyBar.Library.Bar.LegacyBar>(Resource.Id.ActionBar);

            if (LegacyBar != null)
            {
                LegacyBar.Title = Title;
                LegacyBar.Theme = LegacyBarTheme.HoloBlack;

                LegacyBar.SetHomeAction(new ActionLegacyBarAction(this,
                    () => _slidingMenu.Toggle(true),
                    Resource.Drawable.Menu));

                    LegacyBar.AddAction(new ActionLegacyBarAction(this, () => RefreshCommand.Execute(null),
                        Resource.Drawable.Refresh));

                _slidingMenu = new SlidingMenu(this)
                {
                    Mode = MenuMode.Left,
                    TouchModeAbove = DisableMenuSwipe ? TouchMode.None : TouchMode.Fullscreen,
                    BehindOffset = 50,
                    BehindWidth = 400,
                    ShadowWidth = 20,
                    ShadowDrawableRes = Resource.Drawable.SlidingMenuShadow,
                    SecondaryShadowDrawableRes = Resource.Drawable.SlidingMenuShadowRight
                };

                _slidingMenu.SetBackgroundColor(Color.Black);
                _slidingMenu.AttachToActivity(this, SlideStyle.Content);
                _slidingMenu.SetMenu(Resource.Layout.MenuFrame);

                var menuFragment = new MenuFragment();
                menuFragment.ViewModel = new MenuViewModel();

                SupportFragmentManager.BeginTransaction()
                    .Replace(Resource.Id.MenuFrame, menuFragment).Commit();
            }
        }
    }
}