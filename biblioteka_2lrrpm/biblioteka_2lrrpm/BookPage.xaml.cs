using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookPage : ContentPage
    {
        bool edited = true; // флаг редактирования
        public Book Book { get; set; }
        public BookPage(Book book)
        {
            InitializeComponent();

            Book = book;
            if (book == null)
            {
                Book = new Book();
                edited = false;
            }
            this.BindingContext = Book;
        }

        async void SaveBook(object sender, EventArgs e)
        {
            if (nameEntry.Text != null && nameEntry.Text != "" && authorEntry.Text != null && authorEntry.Text != "" && genreEntry.Text != null && genreEntry.Text != "")
            {
                await Navigation.PopAsync();

                // если добавление
                if (edited == false)
                {
                    // находим в стеке предпоследнюю страницу - то есть MainPage
                    NavigationPage navPage = (NavigationPage)Application.Current.MainPage;
                    IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
                    MainBookPage homePage = navStack[navPage.Navigation.NavigationStack.Count - 1] as MainBookPage;

                    
                }
            }
            else
            {
                await DisplayAlert("Ошибка", "Заполните все поля", "Ок");
            }
        }
    }
}
