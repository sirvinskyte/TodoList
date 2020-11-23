using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoList.Business.Services.Interfaces;
using TodoList.Business.Vo;
using TodoList.Web.ViewModel;

namespace TodoList.Web.Controllers
{
    public class TodoItemsController : Controller
    {
        private readonly IEFDataProvider<TodoItem> _todoItemProvider;
        private readonly IEFDataProvider<Category> _categoryProvider;
        private readonly IMapper _mapper;
        public TodoItemsController(IEFDataProvider<TodoItem> todoItemProvider, IEFDataProvider<Category> categoryProvider, IMapper mapper)
        {
            _todoItemProvider = todoItemProvider;
            _categoryProvider = categoryProvider;
            _mapper = mapper;
        }

        // GET: TodoItems
        public async Task<ActionResult> Index()
        {
            var todoItemData = await _todoItemProvider.GetItemsAsync();
            return View(_mapper.Map<ICollection<TodoItemViewModel>>(todoItemData));
        }

        // GET: TodoItems/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var todoItemData = await _todoItemProvider.GetItemAsync(id);
            return View(_mapper.Map<TodoItemViewModel>(todoItemData));
        }

        // GET: TodoItems/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Categories = await _categoryProvider.GetItemsAsync();
            return View(_mapper.Map<TodoItemViewModel>(new TodoItem()));
        }

        // POST: TodoItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TodoItemViewModel todoItemViewModel)
        {
            try
            {
                var todoItem = _mapper.Map<TodoItem>(todoItemViewModel);
                await _todoItemProvider.AddItemAsync(todoItem);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ModelState.AddModelError("Status", e.Message);
                ViewBag.Categories = await _categoryProvider.GetItemsAsync();
                return View(todoItemViewModel);
            }
        }

        // GET: TodoItems/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Categories = await _categoryProvider.GetItemsAsync();
            var todoItemData = await _todoItemProvider.GetItemAsync(id);
            return View(_mapper.Map<TodoItemViewModel>(todoItemData));
        }

        // POST: TodoItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TodoItemViewModel todoItemViewModel)
        {
            try
            {
                var todoItem = _mapper.Map<TodoItem>(todoItemViewModel);
                await _todoItemProvider.UpdateItemAsync(todoItem);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Categories = await _categoryProvider.GetItemsAsync();
                return View(todoItemViewModel);
            }
        }

        // GET: TodoItems/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var todoItemData = await _todoItemProvider.GetItemAsync(id);
            return View(_mapper.Map<TodoItemViewModel>(todoItemData));
        }

        // POST: TodoItems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, TodoItemViewModel todoItemViewModel)
        {
            try
            {
                await _todoItemProvider.DeleteItemAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(todoItemViewModel);
            }
        }
    }
}
