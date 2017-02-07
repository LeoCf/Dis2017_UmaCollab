using System;
using System.Windows.Input;
using umaCollabApp.Data;
using umaCollabApp.Data.DataService;
using umaCollabApp.entities.Exceptions;
using umaCollabApp.Entities;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views;
using umaCollabApp.Views.Users;
using Xamarin.Forms;

namespace umaCollabApp.ViewModel.Users
{
    public class UserRegisterViewModel : ViewModelBase<User>
    {
        private ICommand _saveCommand;
        private ICommand _deleteCommand;
        private ICommand _updateCommand;
        private ICommand _backCommand;
        private UserDataService _dataService;

        public UserRegisterViewModel()
        {
            _dataService = new UserDataService(DependencyService.Get<ISQLite>().GetConnection());
        }

        public UserRegisterViewModel(User user)
            : this() //chama o construtor anterior
        {
            CurrentEntity = user;
        }

        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new Command(() =>
                {
                    try
                    {
                        CurrentEntity.Validate();
                        _dataService.Save(CurrentEntity);
                        Message.DisplayAlert("Success", "You are registered!", "Ok");
                        Navigation.PushAsync(new UserListViewPage());
                    }
                    catch (MandatoryException mandatory)
                    {
                        Message.DisplayAlert("Error", mandatory.Message, "Ok");
                    }
                    catch (Exception)
                    {
                        Message.DisplayAlert("Error", "Error on saving the registry", "Ok");
                    }
                }));
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new Command(async () =>
                {
                    try
                    {
                        var action = await Message.DisplayActionSheet("Do you really want to delete this user?", "Cancel", null, "Yes",
                            "No");
                        switch (action)
                        {
                            case "Yes":
                                _dataService.Delete(CurrentEntity);
                                await Message.DisplayAlert("Success", "User has been deleted.", "Ok");
                                await Navigation.PushAsync(new UserListViewPage());
                                break;

                            case "No":
                            default:
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        await Message.DisplayAlert("Error", "Error on deleting the registry", "Ok");
                    }
                }));
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                return _updateCommand ?? (_updateCommand = new Command(() =>
                {
                    try
                    {
                        CurrentEntity.Validate();
                        _dataService.Update(CurrentEntity);
                        Message.DisplayAlert("Success", "User updated!", "Ok");
                        Navigation.PushAsync(new UserListViewPage());
                    }
                    catch (MandatoryException mandatory)
                    {
                        Message.DisplayAlert("Error", mandatory.Message, "Ok");
                    }
                    catch (Exception)
                    {
                        Message.DisplayAlert("Error", "Error on updating the registry", "Ok");
                    }
                }));
            }
        }

        public ICommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new Command(() =>
                {
                    Navigation.PushAsync(new HomeViewPage());
                }));
            }
        }
    }
}