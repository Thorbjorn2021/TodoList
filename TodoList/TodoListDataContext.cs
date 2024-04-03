using DatabindingSampleWPF;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;


namespace TodoList
{
    public class TodoListDataContext : ObservableObject
    {
        public ObservableCollection<Todo> Todos { get; } = new ObservableCollection<Todo>();
        IStorageService StorageService = new JsonFileStorageService("todos.txt");
        public void AddTodo(Todo todo)
        {
            if (todo == null) return;
            Todos.Add(todo);
            RaisePropertyChanged(nameof(IsSaveChangesEnabled));
        }

        private Todo? _selectedTodo;

        public Todo? SelectedTodo
        {
            get => _selectedTodo;
            set
            {
                Set(ref _selectedTodo, value);
                RaisePropertyChanged(nameof(IsRemoveTodoEnabled));
            }
        }

        public bool IsRemoveTodoEnabled => SelectedTodo != null;

        public void RemoveTodo()
        {
            if(SelectedTodo == null) return;
            Todos.Remove(SelectedTodo);
        }

        public void StoreTodos()
        {
            StorageService.StoreData(Todos.ToList());
        }

        public void RetrieveTodos() { 
            foreach(Todo todo in StorageService.RetrieveData())
            {
                Todos.Add(todo);
            }
            RaisePropertyChanged(nameof(IsSaveChangesEnabled));
        }

        public bool IsSaveChangesEnabled => Todos.Count > 0;
    }

}
