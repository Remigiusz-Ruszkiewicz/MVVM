using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{

    sealed class MainViewModel : INotifyPropertyChanged
    {
        private User user;
        public MainViewModel()
        {
            user = new User
            {
                FirstName = FirstName,
                LastName = LastName
            };
        }
        public string FullName => firstName + " " + lastName;
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChange("firstName");
                    OnPropertyChange("FullName");
                }
            }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChange("lastName");
                    OnPropertyChange("FullName");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
