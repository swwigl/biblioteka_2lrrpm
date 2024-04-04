using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu1 : ContentPage
    {
        public Menu1()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            MainBookPage book = new MainBookPage();
            await Navigation.PushAsync(book);
        }
        async void Ex(object sender, EventArgs e)
        {
            MainPage page = new MainPage();
            await Navigation.PushAsync(page);
        }
    }
}
