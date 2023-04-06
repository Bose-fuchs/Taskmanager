using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Taskmanager.ViewModels.Base;

namespace Taskmanager.ViewModels
{
    internal class MainWindow_VM : VM_Base
    {
        #region Заголовок окна
        /// <summary>
        /// Это заголовок окна
        /// </summary>
        private string _Title = "Планировщик задач";
        public string Title
        {
            get => _Title;

            set => Set(ref _Title, value);
        } 
        #endregion


    }
}
