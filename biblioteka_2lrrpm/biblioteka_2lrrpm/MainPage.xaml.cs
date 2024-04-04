using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace biblioteka_2lrrpm
{
    public partial class MainPage : ContentPage
    {
        // Ключ для хранения данных о зарегистрированных пользователях
        const string UsersKey = "RegisteredUsers";

        public ObservableCollection<User> Users { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Users = new ObservableCollection<User>();

            // Загрузка ранее зарегистрированных пользователей из Preferences
            var savedUsersJson = Preferences.Get(UsersKey, string.Empty);
            if (!string.IsNullOrWhiteSpace(savedUsersJson))
            {
                Users = JsonConvert.DeserializeObject<ObservableCollection<User>>(savedUsersJson);
            }
        }

        public void AddUser(User user)
        {
            Users.Add(user);
            SaveUsers(); // Сохранение пользователей после добавления нового пользователя
        }

        private void SaveUsers()
        {
            // Сериализация списка пользователей в формат JSON и сохранение в Preferences
            var usersJson = JsonConvert.SerializeObject(Users);
            Preferences.Set(UsersKey, usersJson);
        }

        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            // Переход на страницу регистрации
            await Navigation.PushAsync(new RegistrationPage(this));
        }

        private async void AuthenticateUser(object sender, EventArgs e)
        {
            string login = Log.Text;
            string password = Pas.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Ошибка", "Введите логин и пароль", "OK");
                return;
            }

            // Проверяем наличие зарегистрированных пользователей
            if (Users.Count == 0)
            {
                await DisplayAlert("Ошибка", "Нет зарегистрированных пользователей", "OK");
                return;
            }

            // Поиск пользователя
            User user = Users.FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user != null)
            {
                if ((user.Login == "Airat" && user.Password == "1mjp5vl4") || (user.Login == "Bulatka" && user.Password == "1mjrwm7r"))
                {
                    // Пользователь с логином "Airat" и паролем "1mjp5vl4" или с логином "Bulatka" и паролем "12345678" является администратором
                    await Navigation.PushAsync(new Menu2());
                }
                else
                {
                    // Переход на страницу после успешной аутентификации для обычных пользователей
                    await Navigation.PushAsync(new Menu());
                }
            }
            else
            {
                await DisplayAlert("Ошибка", "Пользователь с таким логином и паролем не найден", "OK");
            }
        }

        private User FindUser(string login, string password)
        {
            return Users.FirstOrDefault(u => u.Login == login && u.Password == password);
        }
    }
}
