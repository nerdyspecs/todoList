using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using TodoList.Data;
using TodoList.Models;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Controllers
{
    public class TodosController : Controller
    {
        private readonly  TodoListDbContext _context;

        public TodosController(TodoListDbContext context)
        {
            _context = context;
        }
        //// Display List
        public ActionResult Index()
        {
            var todos = _context.Todos.ToList();
            return View(todos);
        }

        // Add Item (GET)
        public ActionResult Create()
        {
            return View();
        }

        // Add Item (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Todo todo)
        {
            if (ModelState.IsValid)
            {
                _context.Todos.Add(todo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // Delete Item
        public ActionResult Delete(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Create Item

    }
}
