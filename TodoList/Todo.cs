using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class Todo
    {

        public Todo(string title, string description, string priority) {
            Title = title;
            Description = description;
            Priority = priority;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Priority { get; private set; }

        public override string ToString()
        {
            return $"{Title} | {Description} | {Priority}";
        }
    }
}
