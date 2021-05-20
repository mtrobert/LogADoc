using LogADoc.Data;
using LogADoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogADoc.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
            return View(objList);
        }

        //GET-Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> StatusDropdown = _db.Statoos.Select(i => new SelectListItem 
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            ViewBag.StatusDropdown = StatusDropdown;
            return View();
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET-Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Items.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        //POST-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Items.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");        

        }

        //GET-Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Items.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        //POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

    }
}
