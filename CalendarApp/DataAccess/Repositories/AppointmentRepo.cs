using DataAccess.DataContext;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AppointmentRepo : IAppointment
    {
        private readonly AppointmentsContext _appointmentsContext;

        public AppointmentRepo(AppointmentsContext appointmentRepository)
        {
            _appointmentsContext = appointmentRepository;
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _appointmentsContext.Appointments;
        }

        public void AddAppointment(Appointment appointment)
        {
            _appointmentsContext.Appointments.Add(appointment);
            _appointmentsContext.SaveChanges();
        }
    }
}
