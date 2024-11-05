using Code_first_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Code_first_Assignment.Controllers
{
    public class HospitalController: Controller
    {
        private readonly MyContext _context;
        public HospitalController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var hospital = _context.Hospitals.ToList();
            return View(hospital);
        }
        public IActionResult Details(int id)
        {
            var hospital = _context.Hospitals.FirstOrDefault(a => a.HospitalId == id);
            return View(hospital);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                _context.Hospitals.Add(hospital);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(hospital);
        }
        public IActionResult Edit(int id)
        {
            var hospital = _context.Hospitals.FirstOrDefault(a => a.HospitalId == id);
            return View(hospital);
        }
        [HttpPost]
        public IActionResult Edit(Hospital hospital)
        {
            if (hospital != null)
            {
                _context.Entry(hospital).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(hospital);
        }
        public IActionResult Delete(int id)
        {
            var hospital = _context.Hospitals.FirstOrDefault(a => a.HospitalId == id);
            return View(hospital);
        }
        [HttpPost("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var hospital = _context.Hospitals.FirstOrDefault(a => a.HospitalId == id);
            if (hospital != null)
            {
                _context.Hospitals.Remove(hospital);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(hospital);
        }
    }
}
