using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Taskmanager.ViewModels
{
    class ViewModelTest:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private int _Cliks;
        public int Cliks 
        { 
            get { return _Cliks; }
            set 
            {
                _Cliks = value;
                OnPropertyChanged();
            }
        }

        public ViewModelTest()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Delay(1000).Wait();

                    Cliks++;
                }
            });
        }


    }
}
