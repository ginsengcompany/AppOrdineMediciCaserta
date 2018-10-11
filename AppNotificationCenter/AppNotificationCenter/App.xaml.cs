﻿using AppNotificationCenter.Database.Data;
using AppNotificationCenter.Views;
using Xamarin.Forms;
using Com.OneSignal;

namespace AppNotificationCenter
{
    public partial class App : Application
    {

        private const string APP_ID_ONE_SIGNAL = "b560b667-aa97-4980-a740-c8fc7925e208";

        public App()
        {
            InitializeComponent();
            Database.Database.Initialize();
            check();
        }

        private void check()
        {
            var user = checkUser();
            if (user)
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        MainPage = new NavigationPage(new ListaEventiIoS());
                        break;
                    default:
                        MainPage = new NavigationPage(new MainPage());
                        break;
                }
            }
            else
                MainPage = new Login();
            OneSignal.Current.StartInit(APP_ID_ONE_SIGNAL)
                  .EndInit();
        }

        private bool checkUser()
        {
            int count = LoginData.GetCountUser();
            if (count > 0)
                return true;
            else
                return false;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            OneSignal.Current.IdsAvailable(((string userID, string pushToken) =>
            {
                App.Current.Properties["token"] = userID;
                
            }));
            
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