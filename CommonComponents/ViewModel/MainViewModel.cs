using GalaSoft.MvvmLight;
using CommonComponents.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System.Windows.Input;
using System;


namespace CommonComponents.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly INavigationService _navigationservice;
        private readonly INavigationService _gobackservice;
        
       
        
        
        public const string WelcomeTitlePropertyName = "WelcomeTitle";
        public const string MailPropertyName = "Mail";
        public const string PasswordPropertyName = "PasswordProperty";

        public const string mail = "gokberkhayali";
        public const string password = "123456";

        private string _welcomeTitle = string.Empty;
        private string _mail = string.Empty;
        private string _password = string.Empty;
        
        
        
        
  

    
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }

            set
            {
                if (_welcomeTitle == value)
                {
                    return;
                }

                _welcomeTitle = value;
                RaisePropertyChanged(WelcomeTitlePropertyName);
            }
        }



        public string Mail
        {
            get
            {
                return _mail;
            }
            set
            {
                if (_mail == value)
                {
                    return;
                }

                _mail = value;
                RaisePropertyChanged(MailPropertyName);
            }




        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                if (_password == value)
                {
                    return;
                }

                _password = value;
                RaisePropertyChanged(PasswordPropertyName);
            }
        }



        public MainViewModel(IDataService dataService, INavigationService navigationService,
                                INavigationService gobackService)
        {
            _navigationservice = navigationService;
            _gobackservice = gobackService;
           
            _dataService = dataService;

            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
        }

        private RelayCommand _navigate;

  
        public RelayCommand Navigate
        {
            get
            {
                return _navigate
                    ?? (_navigate = new RelayCommand(
                                          () =>
                                          {
                                              //if (Mail == mail && Password == password)
                                              
                                              {
                                                  _navigationservice.Navigate(new Uri("W8.SecondPage.xaml", UriKind.Relative));
                                              }


                                          }));
            }
        }

        private RelayCommand _comeback;


        public RelayCommand ComeBack
        {
            get
            {
                return _comeback
                    ?? (_comeback = new RelayCommand(
                                          () =>
                                          {
                                             
                                            _gobackservice.GoBack();
                                             

                                          }));
            }
        }


        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}