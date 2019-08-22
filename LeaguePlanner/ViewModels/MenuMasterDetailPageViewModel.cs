using LeaguePlanner.Models;
using LeaguePlanner.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using Xamarin.Forms;


namespace LeaguePlanner.ViewModels
{

    public class MenuMasterDetailPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public ObservableCollection<ItemsMenu> MenuItems { get; set; }
        public DelegateCommand NavigateCommand { get; private set; }
        public MenuMasterDetailPageViewModel(INavigationService navigationService):base(navigationService)
        {
            _navigationService = navigationService;
            MenuItems = new ObservableCollection<ItemsMenu>();
            GetMenu();
            NavigateCommand = new DelegateCommand(Navigate);
        }

        private ItemsMenu selectedMenuItem;
        public ItemsMenu SelectedMenuItem
        {
            get => selectedMenuItem;
            set => SetProperty(ref selectedMenuItem, value);
        }


        async void Navigate()
        {
          //  await NavigationService.NavigateAsync(nameof(MenuMasterDetailPage) + "/" + nameof(NavigationPage) + "/" + SelectedMenuItem.PageName);
          await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + SelectedMenuItem.PageName);

        }

        public void GetMenu()
        {
          
            MenuItems.Add(new ItemsMenu
            {
                Icon = "Entrenador.png",
                Title = "Jugadores",
                PageName = "RegisterPlayer"
            });

            MenuItems.Add(new ItemsMenu
            {
                Icon = "PayMoney.Png",
                Title = "Pago Mensualidades",
                PageName = "MainPage"
            });
            MenuItems.Add(new ItemsMenu
            {
                Icon = "Statistics.Png",
                Title = "Estadisticas",
                PageName = "StatisticsPage"
            });

            MenuItems.Add(new ItemsMenu
            {
                Icon = "SettingIcon.Png",
                Title = "Configuracion",
                PageName = "SettingPage"
            });

            MenuItems.Add(new ItemsMenu
            {
                Icon = "Marcador.png",
                Title = "Marcador",
                PageName = "MarcadorPage"
            });




        }

    }

}
