using Android.App;
using Core;
using Core.Services;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Plugins.Messenger;

namespace App.Services
{
    public class FooService : IFooService
    {
        private readonly IMvxMessenger messenger;
        private readonly IMvxAndroidCurrentTopActivity topActivity;

        private MvxSubscriptionToken token;

        public FooService(IMvxAndroidCurrentTopActivity topActivity, IMvxMessenger messenger)
        {
            this.messenger = messenger;
            this.topActivity = topActivity;
        }

        public void Start()
        {
            this.token = this.messenger.SubscribeOnMainThread<Message>(this.OnMessage);
        }

        private void OnMessage(Message obj)
        {
            var dialog = new AlertDialog.Builder(this.topActivity.Activity)
                .SetTitle("FooService")
                .SetMessage("Message received")
                .SetCancelable(true)
                .Create();

            dialog.Show();
        }
    }
}