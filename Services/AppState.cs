using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;

namespace TodoMvcBlazor.Services
{
    public class AppState
    {
        public AppState() => LoadTodos();

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
            StateChanged();
        }

        public void AddRange(IEnumerable<Todo> todos)
        {
            foreach (var todo in todos)
            {
                todo.PropertyChanged += OnItemChanged;
                _todos.Add(todo);
            }
            StateChanged();
        }

        public void RemoveTodo(Todo todo)
        {
            if (_todos.Remove(todo))
            {
                todo.PropertyChanged -= OnItemChanged;
                StateChanged();
            }
        }

        public void ClearCompleted()
        {
            _todos.RemoveAll(t => t.Completed);
            StateChanged();
        }

        public void ToggleAll(bool isChecked)
        {
            foreach (var td in Todos)
            {
                td.Completed = isChecked;
            }
            StateChanged();
        }

        private void LoadTodos()
        {
            // registered in index.html
            var todoStr = RegisteredFunction.Invoke<string>("loadTodos");
            if (string.IsNullOrEmpty(todoStr))
                return;

            var todos = JsonUtil.Deserialize<Todo[]>(todoStr);
            if (todos.Length > 0)
            {
                AddRange(todos);
            }
            OnChange?.Invoke();
        }
        
        private void SaveTodos()
        {
            var todoStr = JsonUtil.Serialize(Todos);
            // registered in index.html
            RegisteredFunction.Invoke<object>("saveTodos", todoStr);
        }

        private void StateChanged()
        {
            OnChange?.Invoke();
            SaveTodos();
        }

        private void OnItemChanged(object sender, PropertyChangedEventArgs e) => StateChanged();
    }
}