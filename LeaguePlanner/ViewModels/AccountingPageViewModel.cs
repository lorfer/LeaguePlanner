using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeaguePlanner.ViewModels
{
    public class AccountingPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public AccountingPageViewModel(INavigationService navigationService ):base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Pagos";
            
        }

    }
}
