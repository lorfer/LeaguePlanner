using LeaguePlanner.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using Xamarin.Forms;


namespace LeaguePlanner.ViewModels
{

    public class MenuMasterDetailPageViewModel : ViewModelBase
    {
        INavigationService _navigationService;

        public ObservableCollection<ItemsMenu> ItemsMenu { get; set; }
        public DelegateCommand NavigationCommand { get; private set; }
        public MenuMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {

            _navigationService = navigationService;
            ItemsMenu = new ObservableCollection<ItemsMenu>();
            // GetMenu();
            NavigationCommand = new DelegateCommand(Navigate);
        }

        private ItemsMenu selectedMenuItem;
        public ItemsMenu SelectedMenuItem
        {
            get => selectedMenuItem;
            set => SetProperty(ref selectedMenuItem, value);
        }


        async void Navigate()
        {

            await _navigationService.NavigateAsync(nameof(NavigationPage) + "/ " + SelectedMenuItem.PageName);

        }

        public void GetMenu()
        {

            ItemsMenu.Add(new ItemsMenu
            {
                Icon = "Player.png",
                Title = "Jugadores",
                PageName = "RegisterPlayer"
            });

            ItemsMenu.Add(new ItemsMenu
            {
                Icon = "Statitics.Png",
                Title = "Estadisticas",
                PageName = "MainPage"
            });
            ItemsMenu.Add(new ItemsMenu
            {
                Icon = "PayMoney.Png",
                Title = "Mensualidades",
                PageName = "AccountingPageViewModel"
            });

            ItemsMenu.Add(new ItemsMenu
            {
                Icon = "SettingIcon.Png",
                Title = "Configuracion",
                PageName = "SettingIcon"
            });


        }

    }

}
