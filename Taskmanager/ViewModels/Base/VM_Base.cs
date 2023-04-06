using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanager.ViewModels.Base
{
    // Абстрактный класс, реализующий интерфейс INotifyPropertyChanged
    internal abstract class VM_Base : INotifyPropertyChanged
    {
        // Событие, уведомляющее о изменении свойства
        public event PropertyChangedEventHandler PropertyChanged;
        // Метод вызова события PropertyChanged
        // [CallerMemberName] - (именно запись - атрибут для компилятора) синтаксический "сахар", позволяющий не указывать параметр
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        // Обновление значения свойства, для которого определено поле хранения данных? || ХЗ зачем, 48 минута видоса 
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        { 
            if (Equals(field, value)) return false;
                field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

    }
}
