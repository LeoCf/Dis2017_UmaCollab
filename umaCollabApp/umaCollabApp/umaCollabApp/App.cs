﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umaCollabApp.Views;
using Xamarin.Forms;

namespace umaCollabApp
{
    public class App : Application
    {
        public static int currentUserId { get; set; }
        public App()
        {
            MainPage = new NavigationPage(new StartViewPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}