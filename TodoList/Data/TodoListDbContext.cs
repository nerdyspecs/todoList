using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Data
{
    public class TodoListDbContext : DbContext
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base (options) {}   
        // Set DB to access Todo Model
        public DbSet<Todo> Todos { get; set; }
    }
}
