using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pharmacyCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacyCMS.Controllers
{
     public class registerationController : Controller
    {
        private readonly ApplicationDbContext _db;
       
        public registerationController(ApplicationDbContext db )
        {
            _db = db;
          
        }
        public  IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(mediciene model)
        {
                _db.mediciene.Add(model);
                _db.SaveChanges ();

            return RedirectToAction("view");


        }
        [HttpPost]
        public IActionResult edit(mediciene obj)
        {
            _db.mediciene.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("view");

        }

        public IActionResult edit(int id)
        {
            return View(_db.mediciene.Find( id));
        }
        public IActionResult view()
        {
            return View(_db.mediciene.ToList());
        }
        public IActionResult Delete(int id)
        {
            var a = _db.mediciene.FirstOrDefault(x => x.id == id);
            _db.mediciene.Remove(a);
            _db.SaveChanges();
            return RedirectToAction("view");
        }

    }
}
