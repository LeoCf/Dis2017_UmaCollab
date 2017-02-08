﻿using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace umaCollabApp.Behaviours
{
    // Password deve conter no mínimo 8 caracteres, 1 numerico, 1 minúsculo, 1 maiúsculo e 1 caractere especial [eg: No1C#madeira]
    class PasswordValidationBehavior : Behavior<Entry>
    {

        const string passwordRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$";



        protected override void OnAttachedTo(Entry bindable)

        {

            bindable.TextChanged += HandleTextChanged;

            base.OnAttachedTo(bindable);

        }


        void HandleTextChanged(object sender, TextChangedEventArgs e)

        {

            bool IsValid = false;

            IsValid = (Regex.IsMatch(e.NewTextValue, passwordRegex));

            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;

        }


        protected override void OnDetachingFrom(Entry bindable)

        {

            bindable.TextChanged -= HandleTextChanged;

            base.OnDetachingFrom(bindable);

        }

    }

}