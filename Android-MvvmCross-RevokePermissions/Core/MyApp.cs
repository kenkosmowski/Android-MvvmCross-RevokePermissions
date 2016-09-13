using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace Core
{
    public class MyApp : MvxApplication
    {
        public override void Initialize()
        {
            this.CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();

            Mvx.ConstructAndRegisterSingleton<IMvxAppStart, AppStart>();
            this.RegisterAppStart(Mvx.Resolve<IMvxAppStart>());
        }
    }
}
