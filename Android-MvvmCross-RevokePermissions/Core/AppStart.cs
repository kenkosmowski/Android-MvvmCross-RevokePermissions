using Core.Services;
using Core.ViewModel;
using MvvmCross.Core.ViewModels;

namespace Core
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        private readonly IFooService fooService;

        public AppStart(IFooService fooService)
        {
            this.fooService = fooService;
        }

        public void Start(object hint = null)
        {
            this.fooService.Start();
            this.ShowViewModel<FirstViewModel>();
        }
    }
}
