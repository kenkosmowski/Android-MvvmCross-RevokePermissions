using MvvmCross.Core.ViewModels;

namespace Core.ViewModel
{
    public class FirstViewModel : MvxViewModel
    {
        public MvxCommand ShowSecondCommand { get; set; }

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

        public FirstViewModel()
        {
            this.ShowSecondCommand = new MvxCommand(this.ShowSecond);
        }

        public void Init()
        {
            this.Text = "First";
        }

        private void ShowSecond()
        {
            this.ShowViewModel<SecondViewModel>();
        }
    }
}
