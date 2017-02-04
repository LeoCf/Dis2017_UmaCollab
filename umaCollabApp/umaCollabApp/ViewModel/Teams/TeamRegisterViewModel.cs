using System;
using System.Windows.Input;
using umaCollabApp.Data;
using umaCollabApp.Data.DataService;
using umaCollabApp.entities;
using umaCollabApp.entities.Exceptions;
using umaCollabApp.Entities;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views.Teams;
using Xamarin.Forms;

namespace umaCollabApp.ViewModel.Teams
{
    class TeamRegisterViewModel : ViewModelBase<Team>
    {
        private ICommand _saveCommand;
        private ICommand _deleteCommand;
        private ICommand _updateCommand;
        private TeamDataService _dataService;
        private bool _saveVisibility;
        private bool _deleteVisibility;
        private bool _updateVisibility;

        public bool SaveVisibility
        {
            get { return _saveVisibility; }
            set
            {
                _saveVisibility = value;
                RaisedPropertyChanged(() => SaveVisibility);
            }
        }

        public bool DeleteVisibility
        {
            get { return _deleteVisibility; }
            set
            {
                _deleteVisibility = value;
                RaisedPropertyChanged(() => DeleteVisibility);
            }
        }

        public bool UpdateVisibility
        {
            get { return _updateVisibility; }
            set
            {
                _updateVisibility = value;
                RaisedPropertyChanged(() => UpdateVisibility);
            }
        }

        public TeamRegisterViewModel()
        {
            _dataService = new TeamDataService(DependencyService.Get<ISQLite>().GetConnection());
            SetVisibility(CurrentTeam.TeamId == 0);
        }

        public TeamRegisterViewModel(Team team)
            : this() //chama o construtor anterior
        {
            CurrentTeam = team;
            SetVisibility(CurrentTeam.TeamId == 0);
        }


        private void SetVisibility(bool isNew)
        {
            SaveVisibility = isNew;
            DeleteVisibility = isNew;
            UpdateVisibility = isNew;
        }

        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new Command(() =>
                {
                    try
                    {
                        CurrentTeam.Validate();
                        _dataService.Save(CurrentTeam);

                        Message.DisplayAlert("Success", "Team registered!", "Ok");
                        Navigation.PushAsync(new TeamListViewPage());
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
                        var action = await Message.DisplayActionSheet("Do you really want to delete this Team?", "Cancel", null, "Yes",
                            "No");
                        switch (action)
                        {
                            case "Yes":
                                _dataService.Delete(CurrentTeam);
                                await Message.DisplayAlert("Success", "Team has been deleted.", "Ok");
                                await Navigation.PushAsync(new TeamListViewPage());
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
                        CurrentTeam.Validate();

                        _dataService.Update(CurrentTeam);
                        Message.DisplayAlert("Success", "Team updated!", "Ok");
                        Navigation.PushAsync(new TeamListViewPage());
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
    }
}
