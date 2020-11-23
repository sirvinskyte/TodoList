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
    public class EFCategoryProvider : IEFDataProvider<Category>
    {
        private readonly AlnaWebApplicationContext _context;
        private readonly IMapper _mapper;
        public EFCategoryProvider(AlnaWebApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddItemAsync(Category category)
        {
            var categoryData = _mapper.Map<CategoryDao>(category);
            _context.Add(categoryData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            _context.Remove(_context.Categories.Find(id));
            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetItemAsync(int id)
        {
            var categoryData = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<Category>(categoryData);
        }

        public async Task<List<Category>> GetItemsAsync()
        {
            var categoryData = await _context.Categories.ToListAsync();
            return _mapper.Map<List<Category>>(categoryData);
        }

        public async Task UpdateItemAsync(Category category)
        {
            var categoryData = _mapper.Map<CategoryDao>(category);
            _context.Update(categoryData);
            await _context.SaveChangesAsync();
        }
    }
}
