using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodoList.Business.Services.Interfaces;
using TodoList.Business.Vo;
using TodoList.Web.ViewModel;

namespace TodoList.Web.Controllers
{
    public class TodoItemTagsController : Controller
    {
        private readonly IEFManyToManyDataProvider<TodoItemTag> _todoItemTagsProvider;
        private readonly IEFDataProvider<Tag> _tagProvider;
        private readonly IEFDataProvider<TodoItem> _todoItemProvider;
        private readonly IMapper _mapper;

        public TodoItemTagsController(IEFManyToManyDataProvider<TodoItemTag> todoItemTagsProvider, IEFDataProvider<Tag> tagProvider,
                                      IEFDataProvider<TodoItem> todoItemProvider, IMapper mapper)
        {
            _todoItemTagsProvider = todoItemTagsProvider;
            _tagProvider = tagProvider;
            _todoItemProvider = todoItemProvider;
            _mapper = mapper;
        }

        // GET: TodoItemTags
        public async Task<ActionResult> Index()
        {
            var todoItemTagData = await _todoItemTagsProvider.GetItemsAsync();
            return View(_mapper.Map<IEnumerable<TodoItemTagViewModel>>(todoItemTagData));
        }

        // GET: TodoItemTags/Details/5
        public async Task<ActionResult> Details(int todoItemId, int tagId)
        {
            var todoItemTagData = await _todoItemTagsProvider.GetItemAsync(todoItemId, tagId);
            return View(_mapper.Map<TodoItemTagViewModel>(todoItemTagData));
        }

        // GET: TodoItemTags/Create
        public async Task<ActionResult> Create()
        {
            ViewData["TagId"] = new SelectList(await _tagProvider.GetItemsAsync(), "Id", "Name") ;
            ViewData["TodoItemId"] = new SelectList(await _todoItemProvider.GetItemsAsync(), "Id", "Name");
            return View();
        }

        // POST: TodoItemTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("TodoItemId,TagId")] TodoItemTagViewModel todoItemTagViewModel)
        {
            if (ModelState.IsValid)
            {
                var todoItemTag = _mapper.Map<TodoItemTag>(todoItemTagViewModel);
                await _todoItemTagsProvider.AddItemAsync(todoItemTag);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TagId"] = new SelectList(await _tagProvider.GetItemsAsync(), "Id", "Name", todoItemTagViewModel.TagId);
            ViewData["TodoItemId"] = new SelectList(await _todoItemProvider.GetItemsAsync(), "Id", "Name", todoItemTagViewModel.TodoItemId);
            return View(todoItemTagViewModel);
        }

        // GET: TodoItemTags/Edit/5
        public async Task<ActionResult> Edit(int todoItemId, int tagId)
        {
            var todoItemTag = await _todoItemTagsProvider.GetItemAsync(todoItemId, tagId);
            if (todoItemTag == null)
            {
                return NotFound();
            }
            ViewData["TagId"] = new SelectList(await _tagProvider.GetItemsAsync(), "Id", "Name", todoItemTag.TagId);
            ViewData["TodoItemId"] = new SelectList(await _todoItemProvider.GetItemsAsync(), "Id", "Name", todoItemTag.TodoItemId);
            ViewData["OldTagId"] = tagId;
            ViewData["OldTodoItemId"] = todoItemId;
            return View(_mapper.Map<TodoItemTagViewModel>(todoItemTag));
        }

        // POST: TodoItemTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int todoItemId, int oldTodoItemId, int tagId, int oldTagId, TodoItemTagViewModel todoItemTagViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var todoItemTag = _mapper.Map<TodoItemTag>(todoItemTagViewModel);
                    await _todoItemTagsProvider.UpdateItemAsync(todoItemTag, oldTodoItemId, oldTagId);
                }
                catch
                {
                    return View(todoItemTagViewModel);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TagId"] = new SelectList(await _tagProvider.GetItemsAsync(), "Id", "Name", todoItemTagViewModel.TagId);
            ViewData["TodoItemId"] = new SelectList(await _todoItemProvider.GetItemsAsync(), "Id", "Name", todoItemTagViewModel.TodoItemId);
            return View(todoItemTagViewModel);
        }

        // GET: TodoItemTags/Delete/5
        public async Task<ActionResult> Delete(int todoItemId, int tagId)
        {
            var todoItemTagData = await _todoItemTagsProvider.GetItemAsync(todoItemId, tagId);
            return View(_mapper.Map<TodoItemTagViewModel>(todoItemTagData));
        }

        // POST: TodoItemTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int todoItemId, int tagId, TodoItemTagViewModel todoItemTagViewModel)
        {
            try
            {
                await _todoItemTagsProvider.DeleteItemAsync(todoItemId, tagId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(todoItemTagViewModel);
            }
        }
    }
}
