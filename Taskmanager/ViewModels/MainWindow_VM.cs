using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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
        private string _Title = "Планировщик";
        public string Title
        {
            get => _Title;

            set => Set(ref _Title, value);
        } 
        #endregion

        public ICommand Maximize_Click
        {
            get
            {
                return new RelayCommand(() =>
                {
                        System.Windows.Application.Current.MainWindow.WindowState = System.Windows.WindowState.Maximized;
                });
            }
        }

        public ICommand Minimize_Click
        {
            get
            {
                return new RelayCommand(() =>
                {
                    System.Windows.Application.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
                });
            }
        }

        public ICommand Close_Click
        {
            get
            {
                return new RelayCommand(() =>
                {
                    System.Windows.Application.Current.Shutdown();
                });
            }
        }


    }
}
