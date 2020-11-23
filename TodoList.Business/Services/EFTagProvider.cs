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
    public class EFTagProvider : IEFDataProvider<Tag>
    {
        private readonly AlnaWebApplicationContext _context;
        private readonly IMapper _mapper;
        public EFTagProvider(AlnaWebApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddItemAsync(Tag tag)
        {
            var tagData = _mapper.Map<TagDao>(tag);
            _context.Add(tagData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            _context.Remove(_context.Tags.Find(id));
            await _context.SaveChangesAsync();
        }

        public async Task<Tag> GetItemAsync(int id)
        {
            var tagData = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);
            return _mapper.Map<Tag>(tagData);
        }

        public async Task<List<Tag>> GetItemsAsync()
        {
            var tagData = await _context.Tags.ToListAsync();
            return _mapper.Map<List<Tag>>(tagData);
        }

        public async Task UpdateItemAsync(Tag tag)
        {
            var tagData = _mapper.Map<TagDao>(tag);
            _context.Update(tagData);
            await _context.SaveChangesAsync();
        }
    }
}
