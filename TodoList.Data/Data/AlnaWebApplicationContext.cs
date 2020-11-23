using Microsoft.EntityFrameworkCore;
using TodoList.Data.Models;

namespace TodoList.Data.Data
{
    public class AlnaWebApplicationContext : DbContext
    {
        public AlnaWebApplicationContext (DbContextOptions<AlnaWebApplicationContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItemTagDao>().HasKey(t => new { t.TodoItemId, t.TagId });
        }

        public DbSet<CategoryDao> Categories{ get; set; }

        public DbSet<TodoItemDao> TodoItems { get; set; }

        public DbSet<TagDao> Tags { get; set; }
        public DbSet<TodoItemTagDao> TodoItemTags { get; set; }
    }
}
