using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;

namespace CalendarApp.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointment _appointmentService;

        public AppointmentsController(IAppointment appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            var appointments = _appointmentService.GetAppointments();
            return View(null);
        }
            
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _appointmentService.AddAppointment(appointment);
                return RedirectToAction("Index");
            }

            return View(appointment);
        }
    }
}
