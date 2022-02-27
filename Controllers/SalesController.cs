using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using pharmacyCMS.Models;
using PharmacyCMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacyCMS.Controllers
{

    [Authorize]
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public   SalesController(ApplicationDbContext db)
        {
            _db = db;

        }
       
        [HttpGet]
        public JsonResult ProductPrice( int par)
        {
            var val = _db.mediciene.Where(x=>x.id==par).FirstOrDefault() ;
            var value = val.price;
            return Json(value);
        }
        public IActionResult create()
        {
            List<mediciene> cities = _db.mediciene.ToList();
            ViewBag.cities = new SelectList(cities, "id", "name");  
            return View();
        }
        [HttpPost]
        public IActionResult create(sales model)
        {
            _db.sales.Add(model);
            _db.SaveChanges();
            return RedirectToAction("view");
        }
        [HttpPost]
        public IActionResult edit(sales obj)
        {
            _db.sales.Update(obj);
            _db.SaveChanges();
            return View();

        }

        public IActionResult edit(int id)
        {
            List<mediciene> cities = _db.mediciene.Where(x=>x.id==id).ToList();
            ViewBag.cities = new SelectList(cities, "id", "name");
            return View(_db.sales.Find(id));
        }
        public IActionResult view(sales model)
        {
          
            var data = _db.sales.ToList();
            List<salesDTO> dto = new List<salesDTO>();
            foreach (var item in data) {
                salesDTO obj = new salesDTO();
                obj.id = item.id;
                obj.name = GetProductName(item.MedicationID);
                obj.price = item.Medicationprice;
                obj.discount = item.discount;
                obj.finalPrice = item.price;
                dto.Add(obj);
            }
            return View(dto);
        }
        public string GetProductName(int id ) { return _db.mediciene.Where(x => x.id == id).Select(x => x.name).FirstOrDefault(); }
        public IActionResult Delete(int id)
        {
            var a = _db.sales.FirstOrDefault(x => x.id == id);
            _db.sales.Remove(a);
            _db.SaveChanges();
            return RedirectToAction("view");
        }


    }
}
