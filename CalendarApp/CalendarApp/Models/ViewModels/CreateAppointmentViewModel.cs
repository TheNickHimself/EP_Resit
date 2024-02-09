namespace CalendarApp.Models.ViewModels
{
    public class CreateAppointmentViewModel
    {
        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
