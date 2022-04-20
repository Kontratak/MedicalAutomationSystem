using Microsoft.AspNetCore.Hosting;
using PatientApp.Helpers;
using PatientApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PatientApp.Middleware
{
    public static class PatientMiddleWare
    {

        public static List<Patient> GetPatients()
        {
            DatabaseOperations dbops = new DatabaseOperations();
            DataTable dt = dbops.GetDataTable("select * from Patients");
            List<Patient> list = new List<Patient>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Patient entity = Patient.fromMap(dt.Rows[i]);
                entity.diagnoses = DiagnoseMiddleware.GetDiagnoses(entity.id);
                entity.visits = VisitMiddleware.GetVisits(entity.id);
                list.Add(entity);
            }
            return list;
        }

        public static List<Patient> SearchPatient(string search)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            string query = "select * from Patients where name like '%" + search +
                "%' or surname like '%" + search +
                "%' or ss_number like '%" + search +
                "%' or address like '%" + search +
                "%' or phone_number like '%" + search +
                "%' or email like '%" + search +
                "%' or birth_date like '%" + search +
                "%' or age like '%" + search +
                "%' or height like '%" + search +
                "%' or weight like '%" + search + "%'";
            DataTable dt = dbops.GetDataTable(query);
            List<Patient> list = new List<Patient>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Patient entity = Patient.fromMap(dt.Rows[i]);
                entity.diagnoses = DiagnoseMiddleware.GetDiagnoses(entity.id);
                entity.visits = VisitMiddleware.GetVisits(entity.id);
                list.Add(entity);
            }
            return list;
        }

        public static Patient GetPatient(int id)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            string query = "select * from Patients where id = " + id + " limit 1";
            DataTable dt = dbops.GetDataTable(query);
            Patient entity = Patient.fromMap(dt.Rows[0]);
            entity.diagnoses = DiagnoseMiddleware.GetDiagnoses(entity.id);
            entity.visits = VisitMiddleware.GetVisits(entity.id);
            return entity;
        }

        public static Patient GetLastAddedPatient()
        {
            DatabaseOperations dbops = new DatabaseOperations();
            string query = "select * from Patients order by id desc limit 1";
            DataTable dt = dbops.GetDataTable(query);
            Patient entity = Patient.fromMap(dt.Rows[0]);
            entity.diagnoses = DiagnoseMiddleware.GetDiagnoses(entity.id);
            entity.visits = VisitMiddleware.GetVisits(entity.id);
            return entity;
        }

        public static void RemovePatient(int id)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            DiagnoseMiddleware.RemoveDiagnoses(id);
            VisitMiddleware.RemoveVisits(id);
            dbops.cmd("delete from Patients where id = " + id);
        }

        public static void AddPatient(Patient patient)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            string query = "Insert into Patients(name,surname,ss_number,address,phone_number,email,gender,birth_date,age,height,weight) values('" + patient.name + "','" +
                patient.surname + "','" + patient.ssnumber + "','" + patient.address + "','" + patient.phone_number 
                + "','" + patient.email + "'," + patient.gender + ",'"+ patient.birth_date + "','" + patient.age + "','" + patient.height + "','" + patient.weight + "')";
            dbops.cmd(query);
        }
        public static void UpdatePatient(Patient patient)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            string query = "Update Patients SET name = '"+ patient.name + "' ,surname = '" + patient.surname + "' ,ss_number = '" + patient.ssnumber
                + "' ,address = '" + patient.address + "' ,phone_number = '" + patient.phone_number + "' ,email = '" + patient.email 
                + "' ,gender = " + patient.gender + " ,birth_date = '" + patient.birth_date + "' ,age = '" + patient.age + "' ,height = '" + patient.height +
                "' ,weight = '" + patient.weight + "' WHERE id = " +patient.id;
            dbops.cmd(query);
        }
    }
}
