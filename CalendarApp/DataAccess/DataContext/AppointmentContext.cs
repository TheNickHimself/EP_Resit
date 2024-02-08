using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.DataContext
{
    public class AppointmentsContext : DbContext
    {

        public AppointmentsContext(DbContextOptions<AppointmentsContext> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
    }

}

