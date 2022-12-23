using Crud_operation.Data;
using Crud_operation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crud_operation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Db_contect _db;
        public EmployeeController(Db_contect db_Contect)
        {
            _db = db_Contect;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> onjgetEmployee = _db.Employes.ToList();
            return View(onjgetEmployee);
        }

        public IActionResult create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employes.Add(employee);
                _db.SaveChanges();
                TempData["success"] = "Employee Details Added successfully";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

     
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Employes.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employes.Update(employee);
                _db.SaveChanges();
                TempData["success"] = "Employee Details update successfully";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Employes.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var Id = _db.Employes.Find(id);
            if (Id == null)
            {
                return NotFound();
            }

            _db.Employes.Remove(Id);
            _db.SaveChanges();
            TempData["success"] = "Employee Details  deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
