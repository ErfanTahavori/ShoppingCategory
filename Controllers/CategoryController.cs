using Microsoft.AspNetCore.Mvc;
using Shopping_Project.Database;
using Shopping_Project.Models;

namespace Shopping_Project.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext db;
        public CategoryController(ApplicationDbContext db) { 
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Category> MyCategoryList = db.category.ToList();
            return View(MyCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "name and display order can not have same values");
            }
            if (ModelState.IsValid)
            {
                db.category.Add(category);
                db.SaveChanges();
                TempData["success"] = "Categori Created Successfully";
                return RedirectToAction("Index","Category");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            
            if (id==null || id==0)
            {
                return NotFound();
            }
            
            Category? category = db.category.Find(id);

            if (category == null) 
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.category.Update(category);
                db.SaveChanges();
                TempData["success"] = "Categori Editted Successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = db.category.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
           
            Category category = db.category.Find(id);
            if (category == null) 
            {
                return NotFound();
            }
                db.category.Remove(category);
                db.SaveChanges();
                TempData["success"] = "Categori Deleted Successfully";
                return RedirectToAction("Index", "Category");
            
            return View();
        }

    }
}
