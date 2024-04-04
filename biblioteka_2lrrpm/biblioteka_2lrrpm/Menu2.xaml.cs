using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu2 : ContentPage
    {
        public Menu2()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            UsersListPage userListPage = new UsersListPage(); // Создание экземпляра UserListPage
            await Navigation.PushAsync(userListPage); // Переход на страницу списка пользователей
        }

        async void Ex(object sender, EventArgs e)
        {
            MainPage page = new MainPage();
            await Navigation.PushAsync(page);
        }
    }
}

