using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoList.Business.Services.Interfaces;
using TodoList.Business.Vo;
using TodoList.Data.Data;
using TodoList.Data.Models;

namespace TodoList.Business.Services
{
    public class EFTodoItemTagsProvider : IEFManyToManyDataProvider<TodoItemTag>
    {
        private readonly AlnaWebApplicationContext _context;
        private readonly IMapper _mapper;

        public EFTodoItemTagsProvider(AlnaWebApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddItemAsync(TodoItemTag todoItemTag)
        {
            var todoItemTagData = _mapper.Map<TodoItemTagDao>(todoItemTag);
            _context.Add(todoItemTagData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int todoItemId, int tagId)
        {
            var todoItemTag = await _context.TodoItemTags.Include(t => t.Tag).Include(t => t.TodoItem)
                .FirstOrDefaultAsync(m => m.TodoItemId == todoItemId && m.TagId == tagId);
            _context.Remove(todoItemTag);
            await _context.SaveChangesAsync();
        }

        public async Task<TodoItemTag> GetItemAsync(int todoItemId, int tagId)
        {
            var todoItemTagData = await _context.TodoItemTags.Include(t => t.Tag).Include(t => t.TodoItem)
                .FirstOrDefaultAsync(m => m.TodoItemId == todoItemId && m.TagId == tagId);
            return _mapper.Map<TodoItemTag>(todoItemTagData);
        }

        public async Task<List<TodoItemTag>> GetItemsAsync()
        {
            var todoItemTagData = await _context.TodoItemTags.Include(t => t.Tag).Include(t => t.TodoItem).ToListAsync();
            return _mapper.Map<List<TodoItemTag>>(todoItemTagData);
        }

        public async Task UpdateItemAsync(TodoItemTag todoItemTag, int todoItemId, int tagId)
        {
            await DeleteItemAsync(todoItemId, tagId);
            await AddItemAsync(todoItemTag);
        }
    }
}
