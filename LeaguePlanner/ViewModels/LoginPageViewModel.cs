using Prism.Commands;
using Prism.Navigation;
using LeaguePlanner.Models;
using LeaguePlanner.Service;
using LeaguePlanner.Views;
using Xamarin.Forms;

namespace LeaguePlanner.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {

        private int count = 0;
        private User user = new User();
        readonly Repository repo = new Repository();

        public LoginPageViewModel(INavigationService navigation) : base(navigation)
        {
            Imagen = "Entrenador.jpeg";
        }


        private DelegateCommand registerUser;
        public DelegateCommand RegisterUser =>
            registerUser ?? (registerUser = new DelegateCommand(ExecuteCommandNameAsync));
        async void ExecuteCommandNameAsync()
        {
            count += 1;
            if (count == 3)
            {
                var valid = await Application.Current.MainPage.DisplayAlert("Aviso", "¿Quieres agregar un usuario?", "Si", "No");
                if (valid)
                {
                    var p = new NavigationParameters();
                    p.Add("Model", p);
                    await NavigationService.NavigateAsync("RegistPage");
                }

                count = 0;
            }


        }

        private DelegateCommand btnIngresar;
        public DelegateCommand BtnIngresar =>
            btnIngresar ?? (btnIngresar = new DelegateCommand(ExecuteCommandButton));

        async void ExecuteCommandButton()
        {
            IsRunning = true;
            bool exist = repo.UserExist(user.UserName, user.PassWorld);

            if (exist)
            {
                await NavigationService.NavigateAsync("HomePage");
            }
            user = null;
            IsRunning = false;

        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                SetProperty(ref userName, value);

                user.UserName = userName;
            }
        }

        private string passWorld;
        public string PassWorld
        {
            get { return passWorld; }
            set
            {
                SetProperty(ref passWorld, value);
                user.PassWorld = PassWorld;
            }
        }
    }
}
