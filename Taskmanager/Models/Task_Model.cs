using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using Taskmanager.Properties;
using Taskmanager.Services;

namespace Taskmanager.Models
{
    internal class Task_Model
    {

        public async Task<int> AddQuestAsync(Quests SelectedRow)
        {

            // Инициализация экземпляра класса
            Token token = new Token()
            {
                token = Settings.Default.token,
                guid = Guid.NewGuid(),
                title = SelectedRow.title,
                lore = SelectedRow.lore,
                status = "Status.EXPIRED",
                create = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                expire = DateTimeOffset.Now.ToUnixTimeMilliseconds()
            };

            // Сериализатор
            var serializer = new JavaScriptSerializer();
            // Результат сериализации
            string serializedResult = serializer.Serialize(token);

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(
                    "http://127.0.0.1:8338/create/",
                     new StringContent(serializedResult, Encoding.UTF8, "application/json"));
                response.Content.ReadAsStringAsync().Wait();
                // Получение результата операции
                MessageBox.Show(response.ToString());
            }

            return 1;

        }

        public async Task<ObservableCollection<Quests>> GetQuestAsynk()
        {
            string response = await HTTPClient.client.GetStringAsync($"{Settings.Default.serverName}/get/{Settings.Default.token}");
            Parent parametrs = JsonConvert.DeserializeObject<Parent>(response);
            ObservableCollection<Quests> quests = parametrs.quests;

            return quests;
        }

        public class Parent
        {
            public string login { get; set; }
            public ObservableCollection<Quests> quests { get; set; }
        }
        public class Quests
        {
            public string uuid { get; set; }
            public string title { get; set; }
            public string lore { get; set; }
            public string status { get; set; }
            public long create { get; set; }
            public long expire { get; set; }

        }
    }
}

