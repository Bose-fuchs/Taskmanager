using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Taskmanager.Pages;
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

        #region Стыд, разврат и наркотики
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
        #endregion

        private Page MyTasks;
        private Page MyPurpose;
        private Page Calendar;

        #region Текущая страница Frame
        private Page _CurrentPage;
        public Page CurrentPage
        {
            get => _CurrentPage;
            set => Set(ref _CurrentPage, value);
        }
        #endregion

        #region Поле для "анимации" перехода между страницами
        private double _FrameOpacity;
        public double FrameOpacity
        {
            get => _FrameOpacity;
            set => Set(ref _FrameOpacity, value);
        }
        #endregion

        // Конструктор класса
        public MainWindow_VM()
        {
            MyTasks = new Task_Page();
            Calendar = new Calendar_Page();
            MyPurpose = new MyPurpose_Page();

            FrameOpacity = 1;
            CurrentPage = MyTasks;
        }

        public ICommand MyTask_Btn
        {
            get
            {
                return new RelayCommand(() => SlowOpacity(MyTasks));
            }
        }

        public ICommand Calendar_Btn
        {
            get
            {
                return new RelayCommand(() => SlowOpacity(Calendar));
            }
        }

        public ICommand MyPurpose_Btn
        {
            get
            {
                return new RelayCommand(() => SlowOpacity(MyPurpose));
            }
        }

        /// <summary>
        /// Функция для плавного переключаения между страницами с помощью изменения прозрачности в асинхроне
        /// </summary>
        /// <param name="page"></param>
        public async void SlowOpacity(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i += -0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(10);
                }

                CurrentPage = page;

                for (double i = 0.0; i <= 1.0; i += 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(10);
                }
            });
        }
    }
}
