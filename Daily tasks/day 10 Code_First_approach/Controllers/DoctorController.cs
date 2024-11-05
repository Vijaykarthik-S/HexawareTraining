using Code_first_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Code_first_Assignment.Controllers
{
    public class DoctorController : Controller
    {
        private readonly MyContext _context;
        public DoctorController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var doctor = _context.Doctors.ToList();
            return View(doctor);
        }
        public IActionResult Details(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(a => a.DoctorId == id);
            return View(doctor);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(doctor);
        }
        public IActionResult Edit(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(a => a.DoctorId == id);
            return View(doctor);
        }
        [HttpPost]
        public IActionResult Edit(Doctor doctor)
        {
            if (doctor != null)
            {
                _context.Entry(doctor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(doctor);
        }
        public IActionResult Delete(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(a => a.DoctorId == id);
            return View(doctor);
        }
        [HttpPost("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(a => a.DoctorId == id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(doctor);
        }
    }
}
