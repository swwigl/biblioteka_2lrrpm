using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        bool edited = true; // флаг редактирования
        public User User { get; set; }
        public UserPage(User user)
        {
            InitializeComponent();
            User = user;
            if (user == null)
            {
                User = new User();
                edited = false;
            }
            this.BindingContext = User;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (loginEntry.Text != null && loginEntry.Text != "" && passwordEntry.Text != null && passwordEntry.Text != "")
            {
                // Сохраняем изменения пользователя
                SaveUser();

                // Отображаем сообщение о добавлении нового пользователя
                await DisplayAlert("Успех", "Новый пользователь успешно добавлен", "ОК");

                await Navigation.PopAsync();

                // Если это добавление нового пользователя
                if (!edited)
                {
                    // Находим в стеке предпоследнюю страницу - то есть MainPage
                    NavigationPage navPage = (NavigationPage)Application.Current.MainPage;
                    IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
                    MainUserPage homePage = navStack[navPage.Navigation.NavigationStack.Count - 1] as MainUserPage;

                    if (homePage != null)
                    {
                        // Добавляем нового пользователя на главную страницу
                        homePage.AddUser(User);
                    }
                }
            }
            else
            {
                await DisplayAlert("Ошибка", "Заполните все поля", "Ок");
            }
        }

        // Метод для сохранения изменений пользователя
        private void SaveUser()
        {
            // Добавляем пользователя в список, если его нет
            if (!App.Users.Contains(User))
            {
                App.Users.Add(User);
            }

            // Сохраняем список пользователей
            App.SaveUsers();
        }
    }
}
