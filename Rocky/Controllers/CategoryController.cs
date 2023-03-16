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

        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken] //предотвращает межсайтовую подделку запросов
        public IActionResult Create(Category obj)
		{
			_db.Category.Add(obj); //добавляем в контекст
			_db.SaveChanges(); //сохраняем изменения в базе данных
			return RedirectToAction("Index"); //переадресация на Index
		}
    }
}
