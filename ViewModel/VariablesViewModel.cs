﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Сalculator.Model;

namespace Сalculator.ViewModel
{
    public class VariablesViewModel : INotifyPropertyChanged
    {
        private string _inputKey;
        public string InputKey
        {
            get { return _inputKey; }
            set
            {
                _inputKey = value;
                OnPropertyChanged();
            }
        }

        private string _inputValue;
        public string InputValue
        {
            get { return _inputValue; }
            set
            {
                _inputValue = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Variable> Variables { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }

        public VariablesViewModel()
        {
            Variables = new ObservableCollection<Variable>();
            AddCommand = new RelayCommand(AddItem);
            RemoveCommand = new RelayCommand<Variable>(RemoveItem);
        }

        private void AddItem()
        {
            if (!string.IsNullOrEmpty(InputKey) && !string.IsNullOrEmpty(InputValue))
            {
                Variables.Add(new Variable { Name = InputKey, Value = InputValue });
                InputKey = string.Empty;
                InputValue = string.Empty;
            }
        }

        private void RemoveItem(Variable variable)
        {
            if (Variables.Contains(variable))
            {
                Variables.Remove(variable);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
