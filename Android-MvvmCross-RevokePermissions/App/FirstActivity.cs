using Android.App;
using Android.OS;
using Android.Widget;
using Core.ViewModel;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Views;

namespace App
{
    [Activity(Name = "app.firstactivity")]
    public class FirstActivity : MvxActivity<FirstViewModel>
    {
        private TextView text;
        private Button showSecond;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetContentView(Resource.Layout.First);

            this.text = this.FindViewById<TextView>(Resource.Id.First_Text);
            this.showSecond = this.FindViewById<Button>(Resource.Id.First_ShowSecond);

            var set = this.CreateBindingSet<FirstActivity, FirstViewModel>();
            set.Bind(this.showSecond).To(x => x.ShowSecondCommand);
            set.Bind(this.text).To(x => x.Text);
            set.Apply();
        }
    }
}