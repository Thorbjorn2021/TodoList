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
        public Stack<Todo> UndoAbleTodos { get; } = new Stack<Todo>();
        public void AddTodo(Todo todo)
        {
            if (todo == null) return;
            Todos.Add(todo);
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
            UndoAbleTodos.Push(SelectedTodo);
            Todos.Remove(SelectedTodo);
            RaisePropertyChanged(nameof(IsUndoEnabled));
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
        }

        public void UndoTodo()
        {
   
            if(UndoAbleTodos.Count == 0) return;

                Todo lastTodo = UndoAbleTodos.Pop();
                if (lastTodo != null)
                {
                AddTodo(lastTodo);
                RaisePropertyChanged(nameof(IsUndoEnabled));
            }
                

            
        }

        public bool IsUndoEnabled => UndoAbleTodos.Count > 0;
    }

}
