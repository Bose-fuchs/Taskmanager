using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Taskmanager.Models;
using Taskmanager.ViewModels.Base;

namespace Taskmanager.ViewModels
{
    internal class Task_VM : VM_Base
    {
        private ObservableCollection<Task_Model.Quests> _DataList;
        public ObservableCollection<Task_Model.Quests> DataList
        {
            get => _DataList;
            set => Set(ref _DataList, value);
        }

        private Task_Model.Quests _row;
        public Task_Model.Quests SelectedRow
        {
            get => _row;
            set
            {
                Set(ref _row, value);
            }

        }

        public Task_VM()
        {
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            Task_Model task = new Task_Model();
            DataList = await task.GetQuestAsynk();
        }

        public ICommand AddQuest
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    Task_Model task = new Task_Model();
                    int result = await task.AddQuestAsync(SelectedRow);
                }, () => true);
            }
        }

        public class Quests
        {
            public string Uuid { get; set; }
            public string Title { get; set; }
            public string Lore { get; set; }
            public string Status { get; set; }
            public long Create { get; set; }
            public long Expire { get; set; }

        }
    }
}
