using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace Core.ViewModel
{
    public class SecondViewModel : MvxViewModel
    {
        private readonly IMvxMessenger messenger;

        public MvxCommand PublishMessageCommand { get; set; }

        private string text;
        public string Text
        {
            get { return this.text; }
            set
            {
                this.text = value;
                this.RaisePropertyChanged(() => this.Text);
            }
        }

        public SecondViewModel(IMvxMessenger messenger)
        {
            this.messenger = messenger;
            this.PublishMessageCommand = new MvxCommand(this.PublishMessage);
        }

        public void Init()
        {
            this.Text = "Second";
        }

        private void PublishMessage()
        {
            this.messenger.Publish(new Message(this));
        }
    }
}
