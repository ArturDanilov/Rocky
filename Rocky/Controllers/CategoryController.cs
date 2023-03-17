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


        //GET - CREATE
        public IActionResult Create()
        {
			return View();
		}


        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken] //предотвращает межсайтовую подделку запросов
        public IActionResult Create(Category obj)
		{
            if (ModelState.IsValid) //проверка на валидность
            {
				_db.Category.Add(obj); //добавляем в контекст
				_db.SaveChanges(); //сохраняем изменения в базе данных
				return RedirectToAction("Index"); //переадресация на Index
			}
            return View(obj);
		}

		//GET - EDIT
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var obj = _db.Category.Find(id);

			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken] //предотвращает межсайтовую подделку запросов

        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid) //проверка на валидность
            {
                _db.Category.Update(obj); //обновляем в контексте
                _db.SaveChanges(); //сохраняем изменения в базе данных
                return RedirectToAction("Index"); //переадресация на Index
            }
            return View(obj);
        }

        //GET - DELETE 
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
