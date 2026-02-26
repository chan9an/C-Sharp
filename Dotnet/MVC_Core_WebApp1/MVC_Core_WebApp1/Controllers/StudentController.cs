using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Core_WebApp1.Models;

namespace MVC_Core_WebApp1.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        StudentRepo sRepo = null;
        public StudentController()
        {
            sRepo = new StudentRepo();
        }



        [HttpGet]
        public string[] getAllCities()
        {
            return new string[] { "Pune", "Mumbai", "Chennai", "Bengaluru", "Hyderabad" };
        }
        public ActionResult Index()

        {
            List<Student> sList = sRepo.ShowAllData();
            return View(sList);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            Student sObj = sRepo.ShowDetailsByID(id);

            return View(sObj);
        }
        public ActionResult Details1(int rollNo)
        {
            Student sObj = sRepo.ShowDetailsByID(rollNo);

            return View(sObj);
        }

        public ActionResult StudentDetailsByName(string name)
        {
            return View();
        }

        // GET: StudentController/Create

        
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student s1)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sRepo.AddData(s1);
                }
                return RedirectToAction(nameof(Index));
            }
            catch { 
                return View(); 
            }
         }

                    // POST: StudentController/Create
        

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
