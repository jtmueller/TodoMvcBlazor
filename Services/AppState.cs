using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TodoMvcBlazor.Services
{
    public class AppState
    {
        private readonly List<Todo> _todos = new List<Todo>();
        public IReadOnlyList<Todo> Todos => _todos;

        public IEnumerable<Todo> Active => _todos.Where(t => !t.Completed);
        public IEnumerable<Todo> Completed => _todos.Where(t => t.Completed);

        public event Action OnChange;

        public void AddTodo(string text)
        {
            var todo = new Todo { Text = text };
            todo.PropertyChanged += OnItemChanged;
            _todos.Add(todo);
            NotifyStateChanged();
        }

        public void RemoveTodo(Todo todo)
        {
            if (_todos.Remove(todo))
            {
                todo.PropertyChanged -= OnItemChanged;
                NotifyStateChanged();
            }
        }

        public void ClearCompleted()
        {
            _todos.RemoveAll(t => t.Completed);
            NotifyStateChanged();
        }

        public void ToggleAll(bool isChecked)
        {
            foreach (var td in Todos)
            {
                td.Completed = isChecked;
            }
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        private void OnItemChanged(object sender, PropertyChangedEventArgs e) => NotifyStateChanged();
    }
}