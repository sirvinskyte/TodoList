using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoList.Business.Services.Interfaces;
using TodoList.Business.Vo;
using TodoList.Web.ViewModel;

namespace TodoList.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IEFDataProvider<Category> _categoryProvider;
        private readonly IMapper _mapper;
        public CategoryController( IEFDataProvider<Category> categoryProvider, IMapper mapper)
        {
            _categoryProvider = categoryProvider;
            _mapper = mapper;
        }
        // GET: Category
        public async Task<ActionResult> Index()
        {
            var categoryData = await _categoryProvider.GetItemsAsync();
            return View(_mapper.Map<IEnumerable<CategoryViewModel>>(categoryData));
        }

        // GET: Category/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var categoryData = await _categoryProvider.GetItemAsync(id);
            return View(_mapper.Map<CategoryViewModel>(categoryData));
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoryViewModel categoryViewModel)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryViewModel);
                await _categoryProvider.AddItemAsync(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(categoryViewModel);
            }
        }

        // GET: Category/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var categoryData = await _categoryProvider.GetItemAsync(id);
            return View(_mapper.Map<CategoryViewModel>(categoryData));
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CategoryViewModel categoryViewModel)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryViewModel);
                await _categoryProvider.UpdateItemAsync(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(categoryViewModel);
            }
        }

        // GET: Category/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var categoryData = await _categoryProvider.GetItemAsync(id);
            return View(_mapper.Map<CategoryViewModel>(categoryData));
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, CategoryViewModel categoryViewModel)
        {
            try
            {
                await _categoryProvider.DeleteItemAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(categoryViewModel);
            }
        }
    }
}
