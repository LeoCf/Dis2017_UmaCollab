using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using umaCollabApp.Interfaces;
using Xamarin.Forms;


/*
 * Classes abstractas  base para os ViewModels
 */

namespace umaCollabApp.ViewModel.Base
{
    public abstract class ViewModelBase : ViewModelBase<object>
    {

    }

    public abstract class ViewModelBase<T> : INotifyPropertyChanged
        where T : class, new()
    {

        private T _entity;
        private T _project;
        private T _team;

        public IMessage Message { get; set; }
        public INavigation Navigation { get; set; }

        // propriedades
        public T CurrentEntity
        {
            get { return _entity; }
            set
            {
                _entity = value;
                RaisedPropertyChanged(() => CurrentEntity);
            }
        }

        public T CurrentProject
        {
            get { return _project; }
            set
            {
                _project = value;
                RaisedPropertyChanged(() => CurrentProject);
            }
        }


        public T CurrentTeam
        {
            get { return _team; }
            set
            {
                _team = value;
                RaisedPropertyChanged(() => CurrentTeam);
            }
        }

        
        // construtor
        protected ViewModelBase()
        {
            CurrentEntity = new T();  
            CurrentProject = new T();   
            CurrentTeam = new T();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisedPropertyChanged (string propertyName)
        {
            // delegate invocation
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void RaisedPropertyChanged<T>(Expression<Func<T>> expression)
        {
            var member = expression.Body as MemberExpression;
            var propertyInfo = member.Member as PropertyInfo;

            if(propertyInfo != null)
            {
                // delegate invocation
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyInfo.Name));
            }       
        }
    }
}
