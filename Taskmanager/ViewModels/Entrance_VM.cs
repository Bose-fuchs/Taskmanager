using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Taskmanager.Models;
using Taskmanager.Properties;
using Taskmanager.Services;
using Taskmanager.ViewModels.Base;
using RelayCommand = GalaSoft.MvvmLight.CommandWpf.RelayCommand;

namespace Taskmanager.ViewModels
{
    internal class Entrance_VM : VM_Base
    {
        #region Поле для логина
        private string _Login = null;
        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }
        #endregion

        #region Поле для пароля
        private string _Password = null;
        public string Password
        {
            get => _Password;
            set => Set(ref _Password, value);
        }
        #endregion

        protected Person_Model person = new Person_Model();

        public ICommand Login_Click
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    int resultRequest = await person.Auth(Login, Password);
                    if (resultRequest == 1)
                    {
                        new MainWindow().Show();
                    } else
                    {
                        MessageBox.Show("Ошибка авторизации");
                    }
                }, () =>
                {
                    return true;
                });
            }
        }

        public ICommand Registration_Click
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    int resultRegistration = await person.Registration(Login, Password);

                    switch (resultRegistration)
                    {
                        case 0: // Успешная регистрация
                            int resultRequest = await person.Auth(Login, Password);
                            if (resultRequest == 1)
                            {
                                new MainWindow().Show();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка авторизации");
                            }
                            break;
                        case -3:
                            MessageBox.Show("Такой пользователь уже зарегестрирован");
                            break; // Пользователь уже существует
                        default:
                            MessageBox.Show("Ошибка регистрации");
                            break; // Ошибка
                    }
                }, () =>
                {
                    return true;
                });
            }
        }
    }
}
