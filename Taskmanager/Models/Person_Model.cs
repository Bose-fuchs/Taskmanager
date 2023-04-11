using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using Taskmanager.Properties;
using Taskmanager.Services;

namespace Taskmanager.Models
{
    internal class Person_Model
    {

        #region Описание полей класса сущности Person
        public string Login;
        public string Password;
        public string Token;
        #endregion

        public async Task<int> Auth(string login, string password)
        {
            // Сохранение настроек
            Settings.Default.login = login;
            Settings.Default.Save();
            Settings.Default.Upgrade();
            Settings.Default.password = password;
            Settings.Default.Save();
            try
            {
                // Отправка запроса на аутентификацию и получение токена
                string responseString = await HTTPClient.client.GetStringAsync($"{Settings.Default.serverName}/auth/{login}:{password}");
                Parametrs parametrs = JsonConvert.DeserializeObject<Parametrs>(responseString);
                Settings.Default.token = parametrs.token;
                Settings.Default.Save();

                if (parametrs.code.Equals("1"))
                    return 1;   // Успех
                else
                    return 0;   // Отказ
            }
            catch (Exception)
            {
                return 0;
            }

            //// Инициализация экземпляра класса
            //Token quest = new Token()
            //{
            //    token = "331a7337-27e5-4c9e-a3d7-76d515954f07",
            //    guid = Guid.NewGuid(),
            //    title = "заголовок",
            //    lore = "описание",
            //    status = "Status.EXPIRED",
            //    create = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
            //    expire = DateTimeOffset.Now.ToUnixTimeMilliseconds()
            //};

            //// Сериализатор
            //var serializer = new JavaScriptSerializer();
            //// Результат сериализации
            //string serializedResult = serializer.Serialize(quest);

            //using (var client = new HttpClient())
            //{
            //    var response = await client.PostAsync(
            //        "http://127.0.0.1:8338/auth/hello123:hello321",
            //         new StringContent("", Encoding.UTF8, "application/post"));
            //    MessageBox.Show(response.RequestMessage.ToString());
            //    // Получение результата операции
            //    MessageBox.Show(response.ToString());
            //}
        }

        public async Task<int> Registration(string login, string password)
        {
            // Сохранение настроек
            Settings.Default.login = login;
            Settings.Default.Save();
            Settings.Default.password = password;
            Settings.Default.Save();
            try
            {
                // Отправка запроса на аутентификацию и получение токена
                string responseString = await HTTPClient.client.GetStringAsync($"{Settings.Default.serverName}/register/{login}:{password}");
                RegParametrs parametrs = JsonConvert.DeserializeObject<RegParametrs>(responseString);

                return Convert.ToInt32(parametrs.code);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }

    class Parametrs
    {
        public string code;
        public string token;
    }

    class RegParametrs
    {
        public string code;
        public string tastks;
    }
}
