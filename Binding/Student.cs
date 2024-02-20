using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Binding
{
    public class Student : INotifyPropertyChanged
    {
        private int _salary = 0;
        private string _name = "";
        private string _password = "";
        private int Id { get; set; }
        public string Name { 
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public int Salary
        {
            get => _salary;
            set
            {
                _salary = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public void Save(string filename)
        {
            using (var fs = new FileStream(filename, FileMode.Create))
            {
                JsonSerializer.Serialize(fs, this);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
