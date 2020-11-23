using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.ProjectClient.Api.Models;

namespace TodoList.ProjectClient.Api.Data
{
    public class TodoListProjectClientApiContext : DbContext
    {
        public TodoListProjectClientApiContext (DbContextOptions<TodoListProjectClientApiContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Project { get; set; }

        public DbSet<Client> Client { get; set; }
    }
}
