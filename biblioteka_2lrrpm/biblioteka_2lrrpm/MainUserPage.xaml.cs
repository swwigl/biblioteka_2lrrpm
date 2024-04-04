using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainUserPage : ContentPage
    {
        // Убедитесь, что здесь есть правильный тип для Users
        protected internal ObservableCollection<User> Users { get; set; }

        public MainUserPage()
        {
            InitializeComponent();
            Users = new ObservableCollection<User>
            {
                new User { Login = "Airat", Password = "1mjp5vl4" },
                new User { Login = "Bulatka", Password = "1mjrwm7r" }
            };
            userlist.ItemsSource = Users;
        }

        private async void userlist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            User selectedUser = e.SelectedItem as User;
            if (selectedUser != null)
            {
                // Снимаем выделение
                userlist.SelectedItem = null;
                // Переходим на страницу редактирования элемента 
                await Navigation.PushAsync(new UserPage(selectedUser));
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Переход на страницу со списком пользователей
            await Navigation.PushAsync(new UsersListPage());
        }


        // Добавляем метод AddUser для добавления нового пользователя
        protected internal void AddUser(User user)
        {
            Users.Add(user);
        }

        private async void Ex(object sender, EventArgs e)
        {
            // Переходим на главную страницу
            MainPage page = new MainPage();
            await Navigation.PushAsync(page);
        }
    }
}
