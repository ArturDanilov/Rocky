using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System.Collections;
using System.Collections.Generic;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) //получаем объект ApplicationDbContext через Dependency Injection (ссылку для этого свойства)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objects = _db.Category;
            return View(objects);
        }

        //GET - Create
        public IActionResult Create()
        {
			return View();
		}
    }
}
