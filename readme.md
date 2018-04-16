# Blazor • [TodoMVC](http://todomvc.com)

> Blazor is an experimental .NET web framework using C#/Razor and HTML that runs in the browser with WebAssembly 


## Resources

- [Website](https://github.com/aspnet/Blazor)
- [Documentation](https://learn-blazor.com/getting-started/)
- [FAQ](https://github.com/aspnet/Blazor/wiki/FAQ)

### Articles

- [Blazor: A Technical Introduction](http://blog.stevensanderson.com/2018/02/06/blazor-intro/)

### Support

- Nope. Experimental, remember?

*Let us [know](https://github.com/tastejs/todomvc/issues) if you discover anything worth sharing.*


## Implementation

Because the 0.1 preview of Blazor only supports onclick and onchange events, I had to use onchange
for creating/editing items. That means that when creating a new task, it will be added when the text field
loses focus, even if you didn't hit Enter. Similarly, when editing a task, if you don't change anything 
you can't leave edit mode (Enter doesn't trigger onchange if there are no changes). 
These bugs can be fixed after upgrading to an as-yet-unreleased version of Blazor.

Access to localStorage is currently through javascript interop.

## Credit

Created by [Joel Mueller](https://github.com/jtmueller/TodoMvcBlazor)
