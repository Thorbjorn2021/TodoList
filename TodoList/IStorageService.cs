using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public interface IStorageService
    {
        public void StoreData(List<Todo> data);
        public List<Todo> RetrieveData();
    }
}
