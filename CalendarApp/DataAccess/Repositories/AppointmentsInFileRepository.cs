using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml;

namespace DataAccess.Repositories
{
    public class AppointmentsInFileRepository : IAppointmentRepository
    {

        string filePath;
        public AppointmentsInFileRepository(string pathToJsonFile) { 
            filePath = pathToJsonFile; 
        
            if (System.IO.File.Exists(filePath) == false) {

                using (var myFile = System.IO.File.Create(filePath))
                {
                    myFile.Close();
                }
            }
        }

        public void AddAppointment(Appointment a)
        {
            a.Id = Guid.NewGuid();

            var myList = GetAppointments().ToList();

            myList.Add(a);

            string jsonString = JsonSerializer.Serialize(myList);

            System.IO.File.WriteAllText(filePath, jsonString);

        }

        public IQueryable<Appointment> GetAppointments()
        {

            string allText = System.IO.File.ReadAllText(filePath);

            if (allText == "")
            {
                return new List<Appointment>().AsQueryable();
            }
            else
            {
                try
                {
                    List<Appointment> products = JsonSerializer.Deserialize<List<Appointment>>(allText);
                    return products.AsQueryable();
                }
                catch
                {
                    return new List<Appointment>().AsQueryable();
                }
            }
        }
    }
}
