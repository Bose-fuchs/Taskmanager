using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Taskmanager.Services;
using System.Web.Script.Serialization;
using System.Windows;

namespace Taskmanager.Services
{
    internal class Data
    {
        private static readonly HttpClient client = new HttpClient();

        public Data()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8338/create/");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"user\":\"test\"," +
                              "\"password\":\"bla\"}";

                streamWriter.Write(json);
            }

        }

        public async void GetTask()
        {
            // Инициализация экземпляра класса
            Token quest = new Token()
            {
                token = "331a7337-27e5-4c9e-a3d7-76d515954f07",
                guid = Guid.NewGuid(),
                title = "заголовок",
                lore = "описание",
                status = "Status.EXPIRED",
                create = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                expire = DateTimeOffset.Now.ToUnixTimeMilliseconds()
            };

            // Сериализатор
            var serializer = new JavaScriptSerializer();
            // Результат сериализации
            string serializedResult = serializer.Serialize(quest);

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(
                    "http://127.0.0.1:8338/create/",
                     new StringContent(serializedResult, Encoding.UTF8, "application/json"));
                response.Content.ReadAsStringAsync().Wait();
                // Получение результата операции
                MessageBox.Show(response.ToString());
            }
        }
    }
}
