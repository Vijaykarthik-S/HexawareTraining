using Code_first_Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Code_first_Assignment.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly MyContext _context;
        public AppointmentController(MyContext context) { 
            _context = context;
        }
        public IActionResult Index() {
            //var products = await _context.Products.Include(p => p.Category).ToListAsync(); return View(products);
            var appointment = _context.Appointments.Include(d=> d.Doctors).Include(p=> p.Patients);
            
            return View(appointment);
        }
        public IActionResult Details(int id) {
            var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == id);
            return View(appointment);
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Appointment appointment) {
            if (ModelState.IsValid) {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(appointment);
        }
        public IActionResult Edit(int id) {
            //ViewBag.DoctorID = new SelectList(_context.Doctors, "DoctorID", "DoctorName", patient.DoctorID);



            ViewBag.PatientId = new SelectList(_context.Patients, "PatientId","PatientId");
            ViewBag.DoctorId = new SelectList(_context.Doctors, "DoctorId","DoctorId");
            var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == id);
            return View(appointment);
        }
        [HttpPost]
        public IActionResult Edit(Appointment appointment) {
            if (appointment != null) {
                _context.Entry(appointment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(appointment);   
        }
        public IActionResult Delete(int id) { 
            var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == id);
            return View(appointment);
        }
        [HttpPost("Delete")]
        public IActionResult DeleteConfirm(int id) {
            var appointment = _context.Appointments.FirstOrDefault(a=>a.AppointmentId==id);
            if (appointment != null) {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View (appointment);
        }

    }
}
