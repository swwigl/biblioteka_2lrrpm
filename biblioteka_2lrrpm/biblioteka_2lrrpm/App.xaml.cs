using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Essentials;

namespace biblioteka_2lrrpm
{
    public partial class App : Application
    {
        // Ключ для хранения данных о зарегистрированных пользователях
        const string UsersKey = "RegisteredUsers";

        // Свойство для доступа к списку пользователей
        public static ObservableCollection<User> Users { get; set; }

        public App()
        {
            InitializeComponent();

            // Загрузка списка пользователей при запуске приложения
            LoadUsers();

            MainPage = new NavigationPage(new MainPage());
        }

        // Метод для загрузки списка пользователей
        public static void LoadUsers()
        {
            var savedUsersJson = Preferences.Get(UsersKey, string.Empty);
            if (!string.IsNullOrWhiteSpace(savedUsersJson))
            {
                var savedUsers = JsonConvert.DeserializeObject<List<User>>(savedUsersJson);
                Users = new ObservableCollection<User>(savedUsers);
            }
            else
            {
                Users = new ObservableCollection<User>();
            }
        }

        // Метод для сохранения списка пользователей
        public static void SaveUsers()
        {
            var usersJson = JsonConvert.SerializeObject(Users);
            Preferences.Set(UsersKey, usersJson);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            SaveUsers(); // Сохранение пользователей перед закрытием приложения
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            LoadUsers(); // Загрузка пользователей после возобновления работы приложения
        }
    }
}
