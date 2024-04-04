using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace biblioteka_2lrrpm
{
    public class User : INotifyPropertyChanged
    {
        private string login;
        private string password;
        public string Role;

        public string Login
        {
            get { return login; }
            set
            {
                if (login != value)
                {
                    login = value;
                    OnPropertyChanged("Login");
                }
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
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
