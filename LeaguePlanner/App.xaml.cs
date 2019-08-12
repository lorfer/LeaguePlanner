using Prism;
using Prism.Ioc;
using LeaguePlanner.ViewModels;
using LeaguePlanner.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Plugin.Popups;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LeaguePlanner
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterUser, RegisterUserViewModel>();
            containerRegistry.RegisterForNavigation<RegisterUser>();

            containerRegistry.RegisterForNavigation<RegisterPlayer, RegisterPlayerViewModel>();
            containerRegistry.RegisterForNavigation<MenuMasterDetailPage, MenuMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingPage, SettingPageViewModel>();
            containerRegistry.RegisterForNavigation<AccountingPage, AccountingPageViewModel>();
            containerRegistry.RegisterForNavigation<StatisticsPage, StatisticsPageViewModel>();
        }
    }
}
