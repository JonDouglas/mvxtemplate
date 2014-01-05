using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using MvxTemplate.Android.Views.Base;

namespace MvxTemplate.Android.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : ActivityBase
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }
    }
}