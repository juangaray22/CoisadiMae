using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
//using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoisadiMae.ViewModels
{
    //[ImplementPropertyChanged]
    public class RootPageViewModel : BindableBase
    {
        readonly INavigationService _navigationService;
        public DelegateCommand<string> Navigate { get; set; }

        public RootPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Navigate = new DelegateCommand<string>(NavigateAction);
        }


        Action<string> NavigateAction
        {
            get
            {
                return new Action<string>(x => {

                    _navigationService.NavigateAsync($"BasePageNavigation/{x}", useModalNavigation: false);
                });
            }
        }
    }
}
