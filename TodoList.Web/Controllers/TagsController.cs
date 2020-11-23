using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoList.Business.Services.Interfaces;
using TodoList.Business.Vo;
using TodoList.Web.ViewModel;

namespace TodoList.Web.Controllers
{
    public class TagsController : Controller
    {
        private readonly IEFDataProvider<Tag> _tagProvider;
        private readonly IMapper _mapper;

        public TagsController(IEFDataProvider<Tag> tagProvider, IMapper mapper)
        {
            _tagProvider = tagProvider;
            _mapper = mapper;
        }

        // GET: Tags
        public async Task<ActionResult> Index()
        {
            var tagData = await _tagProvider.GetItemsAsync();
            return View(_mapper.Map<IEnumerable<TagViewModel>>(tagData));
        }

        // GET: Tags/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var tagData = await _tagProvider.GetItemAsync(id);
            return View(_mapper.Map<TagViewModel>(tagData));
        }

        // GET: Tags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Name")] TagViewModel tagViewModel)
        {
            if (ModelState.IsValid)
            {
                var tag = _mapper.Map<Tag>(tagViewModel);
                await _tagProvider.AddItemAsync(tag);
                return RedirectToAction(nameof(Index));
            }
            return View(tagViewModel);
        }

        // GET: Tags/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var tagData = await _tagProvider.GetItemAsync(id);
            return View(_mapper.Map<TagViewModel>(tagData));
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("Id,Name")] TagViewModel tagViewModel)
        {
            if (ModelState.IsValid)
            {
                var tag = _mapper.Map<Tag>(tagViewModel);
                await _tagProvider.UpdateItemAsync(tag);
                return RedirectToAction(nameof(Index));
            }
            return View(tagViewModel);
        }

        // GET: Tags/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var tagData = await _tagProvider.GetItemAsync(id);
            return View(_mapper.Map<TagViewModel>(tagData));
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id, TagViewModel tagViewModel)
        {
            try
            {
                await _tagProvider.DeleteItemAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tagViewModel);
            }
        }
    }
}
