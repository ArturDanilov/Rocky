using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System.Collections;
using System.Collections.Generic;

namespace Rocky.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ApplicationTypeController(ApplicationDbContext db) //получаем объект ApplicationDbContext через Dependency Injection (ссылку для этого свойства)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objects = _db.ApplicationType;
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
        public IActionResult Create(ApplicationType obj)
		{
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Add(obj); //добавляем в контекст
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

            var obj = _db.ApplicationType.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken] //предотвращает межсайтовую подделку запросов

        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid) //проверка на валидность
            {
                _db.ApplicationType.Update(obj); //обновляем в контексте
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
			var obj = _db.ApplicationType.Find(id);
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
			var obj = _db.ApplicationType.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			_db.ApplicationType.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
