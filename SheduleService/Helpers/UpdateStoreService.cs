using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using SheduleService.Data.Models;
using Newtonsoft.Json;
namespace SheduleService.Helpers
{
    public class UpdateStoreService
    {
        private const string _lastUpdateFilePath = "LastUpdate.json";
        private UpdateList _lastUpdateList = new UpdateList();

        public UpdateStoreService()
        {
            if (System.IO.File.Exists(_lastUpdateFilePath))
            {
                File.Create(_lastUpdateFilePath);
            }
            else
            {
                try
                {
                    string content = File.ReadAllText(_lastUpdateFilePath);
                    _lastUpdateList = JsonConvert.DeserializeObject<UpdateList>(content);
                }
                catch (Exception e) {
                    //lastUpdateList = new UpdateList();
                }               
            }
        }
        /*
                                 Написал LINQ-запрос? Молодец! 

            ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
            ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
            ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠛⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠙⠻⠟⠿⠛⠿⢿⣿⣿⡿⠿⠛⠉⠉⠻⠛⠛⠛⠻⢿⣿⣿⣿⣿⣿⣿
            ⣿⣿⣿⣿⣿⣿⣿⢿⡿⠻⠿⣿⠟⠋⠉⠛⠛⠋⠀⠀⠘⠛⠛⠛⠿⢿⣿⣿⣿⣿⣿⣿⡿⠟⠀⠀⠀⠐⢢⠀⠀⠘⡿⠃⠀⠀⠀⠀⠀⠅⠀⠀⠀⣌⣿⣿⣿⣿⣿⣿
            ⣿⣿⣿⣿⣿⣿⠇⠀⡁⠀⠀⠀⠀⠀⣀⠉⠉⠉⠁⠙⠓⠦⠤⠤⢀⣀⣈⣩⠤⠙⠛⠛⠃⠀⠀⠀⠀⠀⠁⠐⢉⠆⣀⣀⣠⡄⠀⠀⠀⠀⡆⢠⠈⡾⠉⠙⠻⣿⣿⣿
            ⣿⣿⣿⣿⣿⠈⠀⠀⠙⣆⠀⠀⠀⣴⡇⠀⠀⠀⣄⠐⠶⠒⠂⠀⠂⠘⢛⣣⣤⠀⠀⠀⠀⠀⠀⠀⠀⢠⡖⠒⢼⣾⡧⠙⢿⣷⡄⠀⢀⣠⡇⠈⢸⠁⠀⠀⠀⠸⠿⣿
            ⣿⣿⣿⣿⣿⡧⠀⠀⠀⠋⠉⠀⣸⣿⠇⠀⠀⠀⠐⢶⠀⢀⣀⣀⣀⣀⣉⣉⠹⠟⠀⠀⣠⣶⣦⡄⠀⢸⠀⠀⢸⠻⠂⠀⢈⣿⣧⠀⣼⣿⡇⠀⡟⠀⣼⣿⣠⡆⠀⣸
            ⣿⣿⣿⣿⣿⣷⡄⠀⠀⢀⢔⣺⣿⠟⠊⠀⠀⠀⠀⣀⣼⣿⣿⡿⠿⠿⠿⣿⣅⣀⡀⠀⠛⠛⠛⠁⠀⣸⣈⣀⣤⣤⣀⢀⡞⠀⠙⠛⠿⣿⡇⣺⣿⠀⡼⣽⣿⣷⣿⣿
            ⣿⣿⣿⣿⣿⣿⣿⡄⣠⣊⣹⣿⡿⠻⠛⠋⢁⣴⣾⣿⡿⠋⠀⠀⠀⠀⠀⠈⠉⢛⣧⣦⣄⣀⡀⣀⣴⣿⡿⠉⠹⠿⢿⣿⣿⣦⣤⣄⣰⣿⣁⣿⡇⢾⣿⣿⣿⣿⣿⣿
            ⣿⣿⣿⣿⠿⣿⣿⡟⠁⢐⣛⣥⠄⡀⠀⠐⢻⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⢀⣾⣿⡙⠛⣿⣿⣇⠛⢿⣿⣿⣆⠀⠀⠀⣀⣤⣼⣴⣿⣟⣛⣿⣿⣇⣼⣿⠟⣿⣿⣿⣿
            ⣿⣿⣿⣿⣾⡿⣿⣶⣾⣾⣿⡾⠟⣋⠀⢠⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⠟⠃⢠⣼⣿⠻⠟⠛⠋⠁⣠⣶⣶⣾⣿⣿⣿⣿⣿⣿⣛⣻⣿⣿⣿⣿⣾⣿⣿⢿⣿
            ⣿⣿⣿⣿⣿⣧⡞⢻⣟⡩⠁⢠⡟⠉⣠⣿⣿⡿⠥⠀⠀⠀⠀⠀⠀⠀⠚⠋⢁⣤⣤⣾⣿⣿⡇⠀⢀⣀⣜⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠁⢠⣿
            ⣿⣿⣿⡿⢿⣿⣿⣿⡟⠁⠀⠀⠰⠀⢿⣿⣿⡆⣠⣤⣤⣤⣴⣾⠇⢸⣿⣶⣾⡏⠉⢻⣿⣿⣧⣛⣛⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣤⣄⢸⣿
            ⣿⣿⣿⡇⠀⠛⠉⠉⠁⠀⠀⠀⠀⠀⠀⢿⣿⣿⠟⢿⣿⡿⠛⠁⣤⠘⢿⣎⠉⠁⠀⠈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡾⣾⣿
            ⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⣾⣿⡷⠀⠘⣿⣿⣇⣀⣀⣠⣤⣴⣴⣦⣁⠀⢀⠠⢀⣴⣿⣿⢿⢙⣿⣿⣿⣿⣿⣿⣿⡆⠈⢍⠛⠿⣿⣿⣿⣿⣿⣿⣿⣿⠛⠀⣿⣿
            ⣿⣿⠇⠀⣆⡀⠀⠀⠀⠀⠀⠛⠋⠀⠀⢰⣿⣿⣿⣿⣾⣿⣿⣿⣿⣿⣿⣽⣤⣶⣿⣿⣿⣿⠄⠂⣿⣿⣾⠟⣿⣿⣿⣿⣾⣿⣿⡔⢻⣿⣿⣿⣿⣿⣿⣾⠃⢰⣿⣿
            ⣧⣿⡆⠀⢠⠂⠀⡄⠙⠛⠒⠄⣀⣠⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠿⣿⣿⣿⣿⡿⠏⣠⠀⢹⣿⣿⢯⡩⡿⢿⢛⣿⣿⣿⣷⡌⢉⣽⣿⣿⣿⠟⠁⠀⢸⣿⣿
            ⡿⣻⣿⣦⣌⣙⣱⣶⣠⣦⠀⢀⣾⣿⠿⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣦⣬⣒⡬⠴⠶⠞⢁⣴⠟⣿⣿⡚⣶⠚⣉⠍⠍⢽⣿⡿⣰⣿⣿⠿⢛⠅⣀⣢⣤⣌⣻⣿
            ⣷⡿⠛⢃⣽⡆⠘⠛⠿⠀⠰⣿⡉⠁⠐⠲⣤⣭⣭⠙⠻⣿⣿⣿⣿⣿⣿⣿⣿⣟⡻⣿⣿⣿⠿⠋⠀⠙⠙⢸⣯⡅⠤⠶⠂⢸⣿⠃⡉⣼⠟⢀⣴⣿⣿⣿⣿⠻⣿⣿
            ⡿⠃⠀⢿⣿⣿⣷⣀⣀⡀⢠⣿⣦⠄⠀⠀⣻⣿⣟⣁⣈⠈⠉⠻⣿⣿⣿⣿⣿⣿⣷⣶⡉⠁⠀⠀⠀⠀⠗⣹⣿⣇⣨⣽⣍⣿⣃⡌⢈⣠⣴⣿⣿⣿⣿⣿⣿⢠⣿⣿
            ⣷⠀⠀⠀⠈⠉⠙⠛⡇⠀⠘⠿⣿⡄⠀⢀⣯⡉⠉⣩⣿⣿⣿⣶⡌⢻⣿⣿⠿⢿⣟⠁⡐⠀⠢⠀⠀⠀⣠⣿⣿⡷⢴⣶⡗⡝⠅⠴⠞⢻⢿⣿⣿⣿⣿⣿⣿⣧⡹⢿
            ⣿⢤⣶⣶⣶⣤⣤⣶⡇⠀⣰⣶⣿⣿⣀⣼⣿⣷⡀⠿⢻⠈⣿⠟⣣⣿⣿⣿⠗⢊⣵⣶⠖⢛⢁⠄⠀⢠⣽⣿⣿⣿⣻⣿⣦⠀⠀⠀⣠⡍⠲⢚⣿⣿⣿⣿⣿⣿⣿⣿
            ⠇⠈⠹⠛⠛⠿⠿⠿⠿⠿⠛⠙⠋⠙⢛⣻⣿⢿⠃⠀⡄⣀⣽⣾⣿⣿⢿⣯⢰⣻⣿⣿⡦⠐⣡⣴⣶⡿⢻⣿⣿⠿⣿⣿⡅⠀⠀⠀⠟⡉⢀⣼⣿⣿⣿⣿⣿⣿⣿⣿
            ⣤⣤⣿⣀⣠⣤⣤⣤⣤⣤⣄⣴⣤⣶⣿⣿⣾⣿⡧⢹⣿⣿⣿⣿⣿⡗⣼⡏⣼⣧⡏⡙⢅⣾⣋⣠⠎⣽⣿⣿⣿⣹⣿⡿⣣⣤⡄⠀⠀⠰⡼⢣⣿⣿⣿⣿⣿⣟⣿⣿
            ⣿⡉⢉⡛⠛⠙⠻⠿⠟⠛⠻⠛⠋⢉⣩⣿⣿⣿⣵⣦⣭⣿⣿⣿⢛⣾⣿⠄⣾⢻⢃⣴⢏⡽⢿⣿⣾⣿⣿⣿⠶⢿⣿⣿⣿⣿⣿⣿⣿⣷⣹⠇⢿⣿⣿⡿⠋⢹⣿⣿
            ⣿⣿⣶⣧⣄⣠⡤⣤⣄⠀⠀⣦⣾⡿⢿⣿⣿⣿⣿⣿⣿⣿⣿⡜⣿⣿⣿⣮⡁⢉⣾⣱⢿⣷⣿⣽⢿⣿⣇⣯⣉⠛⠛⢘⢽⣿⣿⣿⣿⠋⠏⢠⡾⣫⣷⣿⣿⣿⣿⣿
            ⣿⣿⣿⣿⣿⣏⠉⠛⠛⠛⠉⠉⣀⣴⣿⣿⣿⠿⢹⣿⢿⣏⣁⣀⣿⣿⣿⣟⢳⠘⣿⣿⣾⣟⡿⣿⣿⡿⢨⡷⠠⠤⠁⠔⢿⡿⠋⠀⣠⣭⠀⢈⣴⣿⣿⣯⣿⣿⣿⣿
            ⣿⡟⢻⣿⣿⣿⣿⣿⣿⣷⣾⣿⣿⣿⡿⠟⣡⣾⣿⣧⣾⣿⣿⣿⣿⣿⣿⠁⣟⠆⣯⣿⣿⣿⣿⣿⣿⣧⣾⠅⡴⠄⢠⣶⠏⠀⢀⣴⡿⣫⣶⢿⣿⣿⣿⠛⣿⣿⣿⣿
            ⡿⠁⢸⣿⣿⣿⣿⣿⣿⣿⣿⠿⢛⣭⣾⣿⣿⣟⣿⣿⣿⣟⣷⣿⣿⣿⣿⢃⡁⣸⣷⣿⣿⣿⣿⣿⣿⣿⠛⢀⣠⣴⡟⠁⠀⣠⣿⣯⠔⢋⣾⣿⣿⣿⠇⠀⢸⣿⣿⣿
                                    
                                А как насчёт написать своей матери?
        */
        public UpdateList Compare(UpdateList list) {
            UpdateList result = new UpdateList();
            result.GroupsToUpdate = list.EmployeesToUpdate
                .Join(_lastUpdateList.EmployeesToUpdate, curr => curr.Id, last => last.Id, (curr, last) => new { curr = curr, last = last })
                .Where(x => x.curr.LastUpdate > x.last.LastUpdate).Select(x => x.curr).ToList();
            result.GroupsToUpdate = list.GroupsToUpdate
                .Join(_lastUpdateList.GroupsToUpdate, curr => curr.Id, last => last.Id, (curr, last) => new { curr = curr, last = last })
                .Where(x => x.curr.LastUpdate > x.last.LastUpdate).Select(x => x.curr).ToList();
            return result;
        }
        public void UpdateStore(UpdateList list) {
            foreach (var curr in list.EmployeesToUpdate) {
                foreach (var last in _lastUpdateList.EmployeesToUpdate) {
                    last.LastUpdate = curr.LastUpdate;
                }
            }
            foreach (var curr in list.GroupsToUpdate)
            {
                foreach (var last in _lastUpdateList.GroupsToUpdate)
                {
                    last.LastUpdate = curr.LastUpdate;
                }
            }
            WriteLastUpdate(_lastUpdateList);
        }
        public void WriteLastUpdate(UpdateList list) {
            _lastUpdateList = list;
            string content = JsonConvert.SerializeObject(list);
            File.WriteAllText(_lastUpdateFilePath,content);
        }
        public UpdateList GetLastUpdate() => _lastUpdateList;
    }
}
