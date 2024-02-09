using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using CalendarApp.Models.ViewModels;

namespace CalendarApp.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentRepository _appointmentService;

        public AppointmentsController(IAppointmentRepository appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            var appointments = _appointmentService.GetAppointments().ToList();
            var viewModel = appointments
                .Select(a => new CalendarApp.Models.ViewModels.AppointmentViewModel
                {
                    Id = a.Id,
                    Date = a.Date,
                    Title = a.Title,
                    Description = a.Description,
                    PicturePath = a.PicturePath
                });

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAppointmentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var appointment = new Domain.Models.Appointment
                {
                    Date = viewModel.Date,
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    PicturePath = viewModel.PicturePath ?? "NoPicture" // Handle nullability as needed
                };

                _appointmentService.AddAppointment(appointment);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

    }
}
