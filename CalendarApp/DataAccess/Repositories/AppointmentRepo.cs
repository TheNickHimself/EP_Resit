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
    public class AppointmentRepo : IAppointmentRepository
    {
        private readonly AppointmentsContext _appointmentsContext;

        public AppointmentRepo(AppointmentsContext appointmentRepository)
        {
            _appointmentsContext = appointmentRepository;
        }

        public IQueryable<Appointment> GetAppointments()
        {

            return _appointmentsContext.Appointments;
        }

        public void AddAppointment(Appointment appointment)
        {
            try
            {
                _appointmentsContext.Appointments.Add(appointment);
                _appointmentsContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("Failed to add appointment to the database.", ex);
            }
        }

    }
}
