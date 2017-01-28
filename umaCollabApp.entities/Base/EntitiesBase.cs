

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace umaCollabApp.entities.Base
{
    public abstract class EntitiesBase : INotifyPropertyChanged
    {
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

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract void Validate();


    }
}
