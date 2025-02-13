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
        // HomePage
        public ActionResult Index()
        {
            var todos = _context.Todos.ToList();
            return View(todos);
        }

        // View for add Todo
        public ActionResult Create()
        {
            return View();
        }

        // Add Todo
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

        // Delete Todo
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
    }
}
