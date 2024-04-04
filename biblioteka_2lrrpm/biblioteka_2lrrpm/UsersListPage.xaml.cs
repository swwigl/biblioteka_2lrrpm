using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace biblioteka_2lrrpm
{
    public partial class UsersListPage : ContentPage
    {
        public UsersListPage()
        {
            InitializeComponent();
            // Привязка к коллекции пользователей из класса App
            usersListView.ItemsSource = App.Users;
        }

        private async void AddUser_Clicked(object sender, EventArgs e)
        {
            // Переход на страницу добавления нового пользователя
            await Navigation.PushAsync(new UserPage(null));
        }
    }
}
