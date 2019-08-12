using Prism.Commands;
using Prism.Navigation;
using LeaguePlanner.Models;
using LeaguePlanner.Service;
using LeaguePlanner.Views;
using System;
using Xamarin.Forms;
using Rg.Plugins;

using Prism.Plugin.Popups;


namespace LeaguePlanner.ViewModels
{
    public class RegisterUserViewModel : ViewModelBase
    {
        public RegisterUserViewModel(INavigationService navigation) : base(navigation)
        {
            Title = "Registra usuario";

        }
        User user = new User();
        readonly Repository Persistence = new Repository();
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
                user.Name = name;

            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                SetProperty(ref lastName, value);
                user.LastName = lastName;

            }
        }

        private DateTimeOffset date;
        public DateTimeOffset Dates
        {
            get { return date; }
            set
            {
                SetProperty(ref date, value);
                user.Date = date;
            }
        }

        private string username;
        public string UserName
        {
            get { return username; }
            set
            {
                SetProperty(ref username, value);
                user.UserName = username;
            }
        }

        private string passWorld;
        public string PassWorld
        {
            get { return passWorld; }
            set
            {

                SetProperty(ref passWorld, value);
                user.PassWorld = passWorld;

            }
        }

        private DelegateCommand registerUserCommand;
        public DelegateCommand RegisterUserCommand =>
            registerUserCommand ?? (registerUserCommand = new DelegateCommand(ExecuteRegisterUserCommandAsync));
        async void ExecuteRegisterUserCommandAsync()
        {

            if (Persistence.UserExist(user))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Disculpa", $"El Usuario {username} ya esta guardado.", "Ok");
            }
            else
            {

                user.Id += (int)Persistence.GetUsers().Count + 1;
                Persistence.InsertUser(user);

                var message = await Application.Current.MainPage.DisplayAlert("Aviso", "Su Usuario se a guardado Correctamente, ¿Deseas iniciar?", "Si", "No");

                if (message)
                {
                    var p = new NavigationParameters();
                    p.Add("Model", user);
                    await NavigationService.NavigateAsync("HomePageViewModel", p);
                }




            }

        }


    }
}
