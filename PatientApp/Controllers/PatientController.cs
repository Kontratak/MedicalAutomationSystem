using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PatientApp.Helpers;
using PatientApp.Middleware;
using PatientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientApp.Controllers
{
    public class PatientController : Controller
    {

        #region Views

        public IActionResult ListPatients()
        {
            ViewData["Title"] = "List Patients";
            List<Patient> patients = PatientMiddleWare.GetPatients();
            return View(patients);
        }
        [HttpPost]
        public IActionResult ListPatients(string searchval)
        {
            ViewData["Title"] = "Searched "+searchval;
            List<Patient> patients = PatientMiddleWare.SearchPatient(searchval);
            return View(patients);
        }

        public IActionResult AddPatient()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditPatient(int id)
        {
            Patient patient = PatientMiddleWare.GetPatient(id);
            ViewData["Title"] = "Edit Patient " + patient.name + " " + patient.surname;
            return View(patient);
        }
        [HttpGet]
        public IActionResult ViewPatient(int id)
        {
            Patient patient = PatientMiddleWare.GetPatient(id);
            ViewData["Title"] = "View Patient " + patient.name + " " + patient.surname;
            return View(patient);
        }
        #endregion

        #region DiagnoseCalls

        [HttpGet]
        public string getDiagnose(int id)
        {
            return JsonConvert.SerializeObject(DiagnoseMiddleware.GetDiagnose(id));
        }

        [HttpGet]
        public string setDiagnose(int id)
        {
            DiagnoseMiddleware.SetDiagnose(id);
            return "1";
        }

        [HttpGet]
        public string addDiagnose(int id, string diagnosename, string desc, string exp_date)
        {
            Diagnose diagnose = new Diagnose(id, diagnosename, desc, exp_date);
            DiagnoseMiddleware.AddDiagnose(id, diagnose);
            return "1";
        }

        [HttpGet]
        public string removeDiagnose(int id)
        {
            DiagnoseMiddleware.RemoveDiagnose(id);
            return "1";
        }

        #endregion

        #region MedicineCalls

        [HttpGet]
        public string getMedicines(int diagnoseid)
        {
            return JsonConvert.SerializeObject(MedicineMiddleware.GetMedicines(diagnoseid));
        }

        [HttpGet]
        public string setMedicine(int id)
        {
            MedicineMiddleware.SetMedicine(id);
            return "1";
        }

        [HttpGet]
        public string addMedicine(int id, string medname, string usage, string desc, string exp_date)
        {
            Medicine medicine = new Medicine(id, medname, desc, usage, exp_date);
            MedicineMiddleware.AddMedicine(id, medicine);
            return "1";
        }

        [HttpGet]
        public string removeMedicine(int id)
        {
            MedicineMiddleware.RemoveMedicine(id);
            return "1";
        }

        #endregion

        #region VisitCalls

        [HttpGet]
        public string addVisit(int id, string visit_desc, string visit_date)
        {
            Visit visit = new Visit(id, visit_desc, visit_date);
            VisitMiddleware.AddVisit(id, visit);
            return "1";
        }
        [HttpGet]
        public string removeVisit(int id)
        {
            VisitMiddleware.RemoveVisit(id);
            return "1";
        }

        #endregion

        #region PatientCalls

        [HttpGet]
        public string addPatientFunc(string name, string surname, string ssnum, string phone, string address, string birthdate, string age, string email, int gender, string height, string weight)
        {
            Patient patient = new Patient(name, surname, ssnum, address, phone, email, age, birthdate, gender, height, weight);
            PatientMiddleWare.AddPatient(patient);
            return PatientMiddleWare.GetLastAddedPatient().id.ToString();
        }
        [HttpGet]
        public string updatePatient(int id, string name, string surname, string ssnum, string phone, string address, string birthdate, string age, string email, int gender, string height, string weight)
        {
            Patient patient = new Patient(id, name, surname, ssnum, address, phone, email, age, birthdate, gender, height, weight);
            PatientMiddleWare.UpdatePatient(patient);
            return "1";
        }
        [HttpGet]
        public string removePatient(int id)
        {
            PatientMiddleWare.RemovePatient(id);
            return "1";
        }

        #endregion
    }
}
