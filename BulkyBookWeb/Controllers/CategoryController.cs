using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //var category = _db.Categories.ToList();
            //return View(category);

            IEnumerable <Category> objcategoryList= _db.Categories.ToList();
            return View(objcategoryList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category kategorim)
        {
            if (kategorim.Name == kategorim.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError("CustomError","Görüntülenme sırasıyla adı eşleşmiyor.");
            }

            if (ModelState.IsValid)
            {
            _db.Categories.Add(kategorim);
            _db.SaveChanges();
            TempData["success"] = "Kategori başarıyla oluşturuldu";
            return RedirectToAction("Index");
            }

            return View(kategorim);
          
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }

            var kategorisayfa = _db.Categories.Find(id);
            //var kategorisayfan = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var kategorisayfası = _db.Categories.SingleOrDefault(u=>u.Id==id);

            if (kategorisayfa == null)
            {
                return NotFound();
            }

            return View(kategorisayfa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category kategorim)
        {

            if (kategorim.Name == kategorim.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Görüntülenme sırasıyla adı eşleşmiyor.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(kategorim);
                _db.SaveChanges();
                TempData["success"] = "Kategori başarıyla güncellendi";
                return RedirectToAction("Index");
            }

            return View(kategorim);
        }   
        public IActionResult Delete(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }

            var kategorisayfa = _db.Categories.Find(id);
            //var kategorisayfan = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var kategorisayfası = _db.Categories.SingleOrDefault(u=>u.Id==id);

            if (kategorisayfa == null)
            {
                return NotFound();
            }

            return View(kategorisayfa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int?id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Kategori başarıyla silindi";
            return RedirectToAction("Index");          
        }
    }
}
