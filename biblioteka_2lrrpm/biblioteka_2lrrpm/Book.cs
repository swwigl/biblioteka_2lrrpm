using System.ComponentModel;
using Xamarin.Forms;

namespace biblioteka_2lrrpm
{
    public class Book : INotifyPropertyChanged //Изменения в книге
    {
        private string name;
        private string author;
        private string genre;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Author
        {
            get { return author; }
            set
            {
                if (author != value)
                {
                    author = value;
                    OnPropertyChanged("Author");
                }
            }
        }
        public string Genre
        {
            get { return genre; }
            set
            {
                if (genre != value)
                {
                    genre = value;
                    OnPropertyChanged("Genre");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
