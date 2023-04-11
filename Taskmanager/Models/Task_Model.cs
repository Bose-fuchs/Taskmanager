using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanager.Models
{
    internal class Task_Model
    {
        public Guid guid { get; set; }
        // Заголовок
        public string title { get; set; }
        // Описание
        public string lore { get; set; }
        // Статус
        public string status { get; set; }
        // Дата создания
        public long create { get; set; }
        // Дата окончания задачи
        public long expire { get; set; }


    }
}
