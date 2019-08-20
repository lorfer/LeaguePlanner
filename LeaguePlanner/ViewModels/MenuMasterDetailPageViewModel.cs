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

        public ObservableCollection<ItemsMenu> MenusItems { get; set; }
        public DelegateCommand NavigationCommand { get; private set; }
        public MenuMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Menu";
            _navigationService = navigationService;
            MenusItems = new ObservableCollection<ItemsMenu>();
            GetMenu();
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

            await _navigationService.NavigateAsync(nameof(NavigationPage) + "/ " + selectedMenuItem.PageName);

        }

        public void GetMenu()
        {

            MenusItems.Add(new ItemsMenu
            {
                Icon = "Entrenador.png",
                Title = "Jugadores",
                PageName = "RegisterPlayer"
            });

            MenusItems.Add(new ItemsMenu
            {
                Icon = "PayMoney.Png",
                Title = "Pago Mensualidades",
                PageName = "AccountingPage"
            });
            MenusItems.Add(new ItemsMenu
            {
                Icon = "Statistics.Png",
                Title = "Estadisticas",
                PageName = "StatisticsPage"
            });

            MenusItems.Add(new ItemsMenu
            {
                Icon = "SettingIcon.Png",
                Title = "Configuracion",
                PageName = "SettingPage"
            });

            MenusItems.Add(new ItemsMenu
            {
                Icon = "Marcador.png",
                Title = "Marcador",
                PageName = "MarcadorPage"
            });




        }

    }

}
