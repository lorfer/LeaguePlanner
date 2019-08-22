using LeaguePlanner.Models;
using LeaguePlanner.Service;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LeaguePlanner.ViewModels
{
    public class RegisterPlayerViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        Repository rep = new Repository();
        public RegisterPlayerViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            ListOfPlayers = new ObservableCollection<Player>();

        }



        private DelegateCommand commandAddPlayer;
        public DelegateCommand CommandAddPlayer =>
            commandAddPlayer ?? (commandAddPlayer = new DelegateCommand(ExecuteCommandAddPlayer));

        async void ExecuteCommandAddPlayer()
        {
            await _navigationService.NavigateAsync("RegisterPlayer");
        }



        private DelegateCommand searchCommand;
        public DelegateCommand SearchCommand =>
            searchCommand ?? (searchCommand = new DelegateCommand(ExecuteSearchCommand));

        void ExecuteSearchCommand()
        {

            if (string.IsNullOrEmpty(SearchText))
            {
                IsRunning = true;
                ListOfPlayers = listOfPlayers;
                IsRunning = false;
            }
            else
            {
                listOfPlayers = (ObservableCollection<Player>)listOfPlayers.Where(x => x.Name.StartsWith(SearchText));

            }


        }
        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set { SetProperty(ref searchText, value); }
        }

        //private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    //thats all you need to make a search  

        //    if (string.IsNullOrEmpty(e.NewTextValue))
        //    {
        //        ListOfPlayers = listOfPlayers;
        //    }
        //    else
        //    {
        //        listOfPlayers = (ObservableCollection<Player>)ListOfPlayers.Where(x => x.Name.StartsWith(e.NewTextValue));
        //    }
        //}



        private Player playerSelectd;
        public Player PlayerSelected
        {
            get { return playerSelectd; }
            set { SetProperty(ref playerSelectd, value); }
        }

        private ObservableCollection<Player> listOfPlayers;
        public ObservableCollection<Player> ListOfPlayers
        {
            get { return listOfPlayers; }
            set
            {
                SetProperty(ref listOfPlayers, value);

            }
        }


        public ObservableCollection<Player> Testers()
        {
            return new ObservableCollection<Player>
            {
                new Player{
                    Id = 1,
                    Name = "Estarlin",
                    LastName = "Martinez",
                    NickName = "PicÃº",
                    Heith = (float)5.5,
                     Weith = (float)4.5,


                },
                new Player{
                    Id = 1,
                    Name = "Fernando",
                    LastName = "Garcia",
                    NickName = "Lorfe",
                    Heith = (float)5.5,
                     Weith = (float)4.5,


                },
                new Player{
                    Id = 2,
                    Name = "Estarlin",
                    LastName = "Martinez",
                    NickName = "PicÃº",
                    Heith = (float)5.5,
                     Weith = (float)4.5,


                },
                new Player{
                    Id = 3,
                    Name = "Jose",
                    LastName = "Miguel",
                    NickName = "Blade",
                    Heith = (float)5.5,
                     Weith = (float)4.5,


                },

            };

        }
    }
}