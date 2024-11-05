using Code_first_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Code_first_Assignment.Controllers
{
    public class PatientController: Controller
    {
        private readonly MyContext _context;
        public PatientController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var patient = _context.Patients.ToList();
            return View(patient);
        }
        public IActionResult Details(int id)
        {
            var patient = _context.Patients.FirstOrDefault(a => a.PatientId == id);
            return View(patient);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Patients.Add(patient);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(patient);
        }
        public IActionResult Edit(int id)
        {
            var patient = _context.Patients.FirstOrDefault(a => a.PatientId == id);
            return View(patient);
        }
        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            if (patient != null)
            {
                _context.Entry(patient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(patient);
        }
        public IActionResult Delete(int id)
        {
            var patient = _context.Patients.FirstOrDefault(a => a.PatientId == id);
            return View(patient);
        }
        [HttpPost("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var patient = _context.Patients.FirstOrDefault(a => a.PatientId == id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(patient);
        }
    }
}
