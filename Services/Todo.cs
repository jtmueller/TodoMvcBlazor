using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TodoMvcBlazor.Services
{
    public class Todo : INotifyPropertyChanged
    {
        private string _text;
        private bool _completed;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                NotifyPropertyChanged();
            }
        }

        public bool Completed
        {
            get => _completed;
            set
            {
                _completed = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
