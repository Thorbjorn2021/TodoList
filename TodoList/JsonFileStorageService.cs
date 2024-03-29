using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TodoList
{
    public class JsonFileStorageService : IStorageService
    {
        private string _filePath;

        public JsonFileStorageService(string filePath)
        {
            _filePath = filePath;
        }
        public List<Todo> RetrieveData()
        {
            if(File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Todo>>(json);
            }
            else
            {
                return new List<Todo>();
            }
            
            

            
        }

        public void StoreData(List<Todo> data)
        {
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(_filePath, json);
        }
    }
}
