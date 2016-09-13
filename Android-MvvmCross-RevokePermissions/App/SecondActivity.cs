using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Core.ViewModel;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using Uri = Android.Net.Uri;

namespace App
{
    [Activity(Name = "app.secondactivity")]
    public class SecondActivity : MvxActivity<SecondViewModel>
    {
        private Button publishMessage;
        private Button openSettings;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetContentView(Resource.Layout.Second);

            this.publishMessage = this.FindViewById<Button>(Resource.Id.Second_PublishMessage);
            this.openSettings = this.FindViewById<Button>(Resource.Id.Second_OpenSettings);

            var set = this.CreateBindingSet<SecondActivity, SecondViewModel>();
            set.Bind(this.publishMessage).To(x => x.PublishMessageCommand);
            set.Apply();
        }

        protected override void OnResume()
        {
            base.OnResume();

            this.openSettings.Click += this.OnOpenSettingsClicked;
        }

        private void OnOpenSettingsClicked(object sender, EventArgs e)
        {
            var topActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

            var intent = new Intent(Android.Provider.Settings.ActionApplicationDetailsSettings);
            intent.AddCategory(Intent.CategoryDefault);
            intent.SetData(Uri.Parse($"package:{topActivity.PackageName}"));
            intent.AddFlags(ActivityFlags.NoHistory);
            intent.AddFlags(ActivityFlags.ExcludeFromRecents);
            intent.AddFlags(ActivityFlags.ClearTask);
            topActivity.StartActivity(intent);
        }

        protected override void OnPause()
        {
            base.OnPause();

            this.openSettings.Click -= this.OnOpenSettingsClicked;
        }
    }
}