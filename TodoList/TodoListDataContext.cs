using DatabindingSampleWPF;
using System.Collections.ObjectModel;


namespace TodoList
{
    public class TodoListDataContext : ObservableObject
    {
        public ObservableCollection<Todo> Todos { get;  } = new ObservableCollection<Todo>();


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
            Todos.Remove(SelectedTodo);
        }
    }

}
