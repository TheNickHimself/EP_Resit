using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using CalendarApp.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;


namespace CalendarApp.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentRepository _appointmentService;
        private readonly IWebHostEnvironment _webHostEnv;
        public AppointmentsController(IAppointmentRepository appointmentService, IWebHostEnvironment webHostEnv)
        {
            _appointmentService = appointmentService;
            _webHostEnv = webHostEnv;
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
        public IActionResult Create(CreateAppointmentViewModel viewModel, [FromServices] IWebHostEnvironment _webHostEnv)
        {
            if (ModelState.IsValid)
            {
                string relpaht = "";
                if (viewModel.ImageFile != null && viewModel.ImageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(viewModel.ImageFile.FileName);

                    var filePath = Path.Combine(_webHostEnv.WebRootPath, "images", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        viewModel.ImageFile.CopyTo(fileStream);
                    }

                    relpaht = "/images/" + fileName;
                }

                var appointment = new Domain.Models.Appointment
                {
                    Date = viewModel.Date,
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    PicturePath = relpaht ?? "NoPicture" // Handle nullability as needed
                };

                _appointmentService.AddAppointment(appointment);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

    }
}
