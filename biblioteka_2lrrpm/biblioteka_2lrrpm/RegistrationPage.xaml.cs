using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq; // Добавленная директива

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        MainPage mainPage; // Ссылка на главную страницу

        public RegistrationPage(MainPage mainPage)
        {
            InitializeComponent();
            this.mainPage = mainPage; // Сохраняем ссылку на главную страницу
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string login = loginEntry.Text;
            string password = passwordEntry.Text;

            // Проверка на пустые поля логина и пароля
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                DisplayAlert("Ошибка", "Введите логин и пароль", "OK");
                return;
            }

            // Проверка на существующего пользователя с таким же логином
            if (mainPage.Users.Any(u => u.Login == login))
            {
                DisplayAlert("Ошибка", "Пользователь с таким логином уже существует", "OK");
                return;
            }

            // Создаем нового пользователя с введенными данными
            User newUser = new User
            {
                Login = login,
                Password = password
            };

            // Добавляем нового пользователя на главную страницу
            mainPage.AddUser(newUser);

            // Показываем сообщение об успешной регистрации
            DisplayAlert("Успех", "Пользователь успешно зарегистрирован", "OK");

            // Переходим обратно на главную страницу
            Navigation.PopAsync();
        }
    }
}
