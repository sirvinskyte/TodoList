using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoList.Business.Services.Interfaces;
using TodoList.Business.Vo;
using TodoList.Commons;
using TodoList.Data.Data;
using TodoList.Data.Models;

namespace TodoList.Business.Services
{
    public class EFTodoItemProvider : IEFDataProvider<TodoItem>
    {
        private readonly AlnaWebApplicationContext _context;
        private readonly IMapper _mapper;
        public EFTodoItemProvider(AlnaWebApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddItemAsync(TodoItem todoItem)
        {
            if (todoItem.Status == StatusType.Wip && todoItem.Priority == 1)
            {
                var todoItemsData =
                    await _context.TodoItems.FirstOrDefaultAsync(t => t.Status == StatusType.Wip && t.Priority == 1);

                if (todoItemsData != null)
                {
                    throw new Exception("There could be only one TodoItem with status Wip and priority 1");
                }
            }

            if (todoItem.Category != null && todoItem.Category.Id != 0)
            {
                var categoryData = _context.Categories.Find(todoItem.Category.Id);
                todoItem.Category = _mapper.Map<Category>(categoryData);
            }
            else
            {
                todoItem.Category = null;
            }

            var todoItemData = _mapper.Map<TodoItemDao>(todoItem);
            _context.Add(todoItemData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            _context.Remove(_context.TodoItems.Find(id));
            await _context.SaveChangesAsync();
        }

        public async Task<TodoItem> GetItemAsync(int id)
        {
            var todoItemData = await _context.TodoItems.Include(t => t.Category).FirstOrDefaultAsync(t => t.Id == id);
            return _mapper.Map<TodoItem>(todoItemData);
        }

        public async Task<List<TodoItem>> GetItemsAsync()
        {
            var todoItemData = await _context.TodoItems.Include(t => t.Category).ToListAsync();
            return _mapper.Map<List<TodoItem>>(todoItemData);
        }

        public async Task UpdateItemAsync(TodoItem todoItem)
        {
            var todoItemData = _mapper.Map<TodoItemDao>(todoItem);
            if (todoItem.Category != null && todoItem.Category.Id != 0)
            {
                var categoryData = _context.Categories.Find(todoItem.Category.Id);
                todoItemData.Category = categoryData;
            }
            else
            {
                todoItemData.Category = null;
            }
            _context.Entry(todoItemData).Property("CategoryId").IsModified = true;
            _context.Update(todoItemData);
            await _context.SaveChangesAsync();
        }
    }
}
