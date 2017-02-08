using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using umaCollabApp.Interfaces;
using Xamarin.Forms;
/*
 * Modelo base dos view models implementa observers proprios do xamarim para quando uma propriedade muda 
 * */
namespace umaCollabApp.ViewModel.Base
{   
    public abstract class ViewModelList<T> : INotifyPropertyChanged
        where T : class, new()
    {
        public IMessage Message { get; set; }
        public INavigation Navigation { get; set; }

        public ObservableCollection<T> Entities { get; set; }

        public ViewModelList()
        {
                Entities = new ObservableCollection<T>();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisedPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void RaisedPropertyChanged<T>(Expression<Func<T>> expression)
        {
            var member = expression.Body as MemberExpression;
            var propertyInfo = member.Member as PropertyInfo;

            if (propertyInfo != null)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyInfo.Name));
            }
        }
    }
}
