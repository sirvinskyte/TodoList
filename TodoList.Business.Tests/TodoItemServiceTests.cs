using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using TodoList.Business.Services;
using TodoList.Business.Services.Interfaces;
using TodoList.Business.Vo;
using TodoList.Commons;
using TodoList.Data.Data;
using TodoList.Data.Models;
using Xunit;

namespace TodoList.Business.Tests
{
    public class TodoItemServiceTests
    {
        private readonly IMapper mapper;

        public TodoItemServiceTests()
        {
        }
        [Fact]
        public async Task CreateTodoItemWipOne_Create_Pass()
        {
            var dataa = new List<TodoItem>()
            {
                new TodoItem() {Id = 1, Name = "First", Status = StatusType.Wip, Priority = 1},
                new TodoItem() {Id = 2, Name = "Second", Status = StatusType.Wip, Priority = 2}
            };


            var data = new List<TodoItemDao>
            {
                new TodoItemDao() {Id = 1, Name = "First", Status = StatusType.Wip, Priority = 1},
                new TodoItemDao() {Id = 2, Name = "Second", Status = StatusType.Wip, Priority = 2}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<TodoItemDao>>();
            mockSet.As<IQueryable<TodoItemDao>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<TodoItemDao>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TodoItemDao>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<TodoItemDao>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AlnaWebApplicationContext>();
            mockContext.Setup(c => c.TodoItems).Returns(mockSet.Object);

            EFTodoItemProvider todoItemProvider = new EFTodoItemProvider(mockContext.Object, mapper);
            var todoItems = await todoItemProvider.GetItemsAsync();

            Assert.Equal(dataa, todoItems);
        }
    }
}
