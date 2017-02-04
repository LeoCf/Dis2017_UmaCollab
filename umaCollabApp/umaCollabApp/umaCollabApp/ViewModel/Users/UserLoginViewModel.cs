using System;
using System.Windows.Input;
using umaCollabApp.Data;
using umaCollabApp.Data.DataService;
using umaCollabApp.entities.Exceptions;
using umaCollabApp.Entities;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views.Projects;
using umaCollabApp;
using Xamarin.Forms;


namespace umaCollabApp.ViewModel.Users
{
    class UserLoginViewModel : ViewModelBase<User>
    {
        private ICommand _loginCommand;
        private UserDataService _dataService;
        
        


        public UserLoginViewModel()
        {
            _dataService = new UserDataService(DependencyService.Get<ISQLite>().GetConnection());
        }


        public UserLoginViewModel(User user)
            : this() //chama o construtor anterior
        {
            CurrentEntity = user;
        }


        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new Command(() =>
                {
                    try
                    {

                        if (_dataService.Login(CurrentEntity))
                        {
                            Message.DisplayAlert("Success", "You are logged in!", "Ok");
                            GlobalSettings.currentUserId=_dataService.GetCurrentUser(CurrentEntity);
                                    
                            Navigation.PushAsync(new ProjectListViewPage());
                        }
                        else
                            Message.DisplayAlert("Error", "Your credentials don´t match any user!", "Ok");
                             

                        
                    }
                    catch (MandatoryException mandatory)
                    {
                        Message.DisplayAlert("Error", mandatory.Message, "Ok");
                    }
                    catch (Exception)
                    {

                        Message.DisplayAlert("Error", "Login error", "Ok");
                    }

                }));
            }
        }


    }
}
