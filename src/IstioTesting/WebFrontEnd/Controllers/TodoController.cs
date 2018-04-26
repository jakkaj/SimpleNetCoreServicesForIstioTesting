using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using WebFrontEnd.Contracts;

namespace WebFrontEnd.Controllers
{
    public class TodoController : Controller
    {
        private readonly IRemoteTodoService _remoteTodoService;

        public TodoController(IRemoteTodoService remoteTodoService)
        {
            _remoteTodoService = remoteTodoService;
        }
        // GET: Todo
        public async Task<ActionResult> Index()
        {
            var todo = await _remoteTodoService.GetAll();
            return View(todo);
        }

        // GET: Todo/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var todo = await _remoteTodoService.Get(id.ToString());

            return View(todo);
        }

        // GET: Todo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Name,IsComplete")] TodoItem todo)
        {
            try
            {
                await _remoteTodoService.Add(todo);
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Todo/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var todo = await _remoteTodoService.Get(id.ToString());
            return View(todo);
        }

        // POST: Todo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id,Name,IsComplete")] TodoItem todo)
        {
            try
            {
                // TODO: Add update logic here
                await _remoteTodoService.Update(todo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Todo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Todo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _remoteTodoService.Delete(id.ToString());

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}