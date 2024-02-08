using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Repositories;


namespace CalendarApp.Models.ViewModels
{
    public class AppointmentViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? PicturePath { get; set; }
    }
}
