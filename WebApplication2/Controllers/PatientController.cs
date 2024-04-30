//using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApplication2.Controllers
{
    public class PatientController : Controller
    {
        private static List<Patient> _patients = new List<Patient>
        {
            new Patient { Id = 1, Name = "Иван Иванов" },
            new Patient { Id = 2, Name = "Петр Петров" }
        };

        public ActionResult Index()
        {
            return View(_patients);
        }

        // Добавление пациента
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            patient.Id = _patients.Any() ? _patients.Max(p => p.Id) + 1 : 1;
            _patients.Add(patient);
            return RedirectToAction("Index");
        }

        // Редактирование пациента
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
                return NotFound(); 
            return View(patient);
        }

        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            var existingPatient = _patients.FirstOrDefault(p => p.Id == patient.Id);
            if (existingPatient == null)
                return NotFound(); 
            existingPatient.Name = patient.Name;
            return RedirectToAction("Index");
        }

        // Удаление пациента
        public ActionResult Delete(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
                return NotFound(); 
            _patients.Remove(patient);
            return RedirectToAction("Index");
        }
    }
}
