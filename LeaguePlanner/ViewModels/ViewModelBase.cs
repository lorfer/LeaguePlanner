using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaguePlanner.ViewModels
{
        public class ViewModelBase : BindableBase, INavigationAware, IDestructible, IMasterDetailPageOptions
        {
            protected INavigationService NavigationService { get; private set; }


            private bool isRunning;
            private bool isNotRunning;

            private string _title;
            public string Title
            {
                get { return _title; }
                set { SetProperty(ref _title, value); }
            }

            public bool IsRunning
            {
                get
                {
                    return isRunning;
                }
                set
                {
                    //This is for reference to the Prop
                    SetProperty(ref isRunning, value);
                    IsNotRunning = !value;
                }
            }

            public bool IsNotRunning
            {
                get
                {
                    return isNotRunning;
                }
                set
                {
                    SetProperty(ref isNotRunning, value);
                }
            }


            private string imagen;
            public string Imagen
            {
                get { return imagen; }
                set { SetProperty(ref imagen, value); }
            }
            private bool isEnabled;
            public bool IsEnabled
            {
                get { return isEnabled; }
                set { SetProperty(ref isEnabled, value); }
            }

            public bool IsPresentedAfterNavigation { get { return true; } }

            public ViewModelBase(INavigationService navigationService)
            {
                NavigationService = navigationService;
            }

            public virtual void OnNavigatedFrom(INavigationParameters parameters)
            {

            }

            public virtual void OnNavigatedTo(INavigationParameters parameters)
            {

            }

            public virtual void OnNavigatingTo(INavigationParameters parameters)
            {

            }

            public virtual void Destroy()
            {

            }
        }

    }

