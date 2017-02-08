using System;
using System.Windows.Input;
using umaCollabApp.Data;
using umaCollabApp.Data.DataService;
using umaCollabApp.entities.Exceptions;
using umaCollabApp.Entities;
using umaCollabApp.ViewModel.Base;
using umaCollabApp.Views.Projects;
using Xamarin.Forms;
/*
 * Views models dos projectos faz o binding com a vista  respectiva , possuem a logica dos comandos para a navegaçao
 */

namespace umaCollabApp.ViewModel.Projects
{
    class ProjectRegisterViewModel : ViewModelBase<Project>
    {
        private ICommand _saveCommand;
        private ProjectDataService _dataService;
        private bool _saveVisibility;
        private bool _deleteVisibility;
        private bool _updateVisibility;
      
//Comandos de visibilidade dos butoes exemplo so devem surgir apos o utilizdor preencher certos campos 
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

        public ProjectRegisterViewModel()
        {
            _dataService = new ProjectDataService(DependencyService.Get<ISQLite>().GetConnection());
            SetVisibility(CurrentProject.ProjectId == 0);
        }

        public ProjectRegisterViewModel(Project project)
            :this() //chama o construtor anterior
        {
            CurrentProject = project;
            SetVisibility(CurrentProject.ProjectId == 0);
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
                        CurrentProject.Validate();
                        _dataService.Save(CurrentProject,GlobalSettings.currentUserId);

                        Message.DisplayAlert("Success", "Project registered!", "Ok");
                        Navigation.PushAsync(new ProjectListViewPage());
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



    }
}