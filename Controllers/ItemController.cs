using LogADoc.Data;
using LogADoc.Models;
using LogADoc.Models.ViewModels;
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

            foreach (var item in objList)
            {
                item.Status = _db.Statoos.FirstOrDefault(s => s.Id == item.StatusId);
            }
            return View(objList);
        }

        //GET-Create
        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> StatusDropdown = _db.Statoos.Select(i => new SelectListItem 
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});

            //ViewBag.StatusDropdown = StatusDropdown;

            ItemVM itemVM = new ItemVM
            {
                Item = new Item(),
                StatusDropDown = _db.Statoos.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(itemVM);
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ItemVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj.Item);
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
            ItemVM itemVM = new ItemVM
            {
                Item = _db.Items.Find(id),
                StatusDropDown = _db.Statoos.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            //var obj = _db.Items.Find(id);

            if (itemVM.Item == null)
            {
                return NotFound();
            }
            return View(itemVM);

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


            ItemVM itemVM = new ItemVM
            {
                Item = new Item(),
                StatusDropDown = _db.Statoos.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            itemVM.Item = _db.Items.Find(id);
        

            if (itemVM.Item == null)
            {
                return NotFound();
            }
            return View(itemVM);

        }


        //////////////    update status not shown



        //POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ItemVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj.Item);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

    }
}
