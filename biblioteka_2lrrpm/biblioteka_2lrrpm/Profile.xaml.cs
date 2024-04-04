using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace biblioteka_2lrrpm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
        }

        async void GetPhotoAsync(object sender, EventArgs e)
        {
            try
            {
                // выбираем фото
                var photo = await MediaPicker.PickPhotoAsync();
                // проверяем, что выбранное фото не является пустым
                if (photo != null)
                {
                    // загружаем в ImageView
                    img.Source = ImageSource.FromFile(photo.FullPath);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка!", ex.Message, "OK");
            }
        }
        async void TakePhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                // для примера сохраняем файл в локальном хранилище
                var newFile = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                // загружаем в ImageView
                img.Source = ImageSource.FromFile(photo.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка!", ex.Message, "OK");
            }
        }
        async void Ex(object sender, EventArgs e)
        {
            MainPage page = new MainPage();
            await Navigation.PushAsync(page);
        }
    }

}

