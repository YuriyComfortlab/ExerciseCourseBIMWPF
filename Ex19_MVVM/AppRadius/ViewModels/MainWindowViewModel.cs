using AppRadius.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppRadius.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; 

        void OnPropertyChanged([CallerMemberName] string PropertyName = null)                                                                               
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName)); 
        }

        //Свойство для 1 поля
        private int number1;
        public int Number1
        {
            get => number1;
            set
            {
                number1 = value;
                OnPropertyChanged(); 
            }
        }

        //Св-во для 2 поля
        private double number2;
        public double Number2
        {
            get => number2;
            set
            {
                number2 = value;
                OnPropertyChanged();
            }
        }

       
        
        public ICommand AddCommand { get; }

       
        private void OnAddCommandExecute(object p)
        {
            Number2 = Arith.LengthCircle(Number1);
        }
        private bool CanAddCommandExecuted(object p)
        {
            if (Number1 != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted);
        }
    }
}
