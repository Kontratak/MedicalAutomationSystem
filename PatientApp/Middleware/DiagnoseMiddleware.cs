using PatientApp.Helpers;
using PatientApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PatientApp.Middleware
{
    public static class DiagnoseMiddleware
    {
        public static List<Diagnose> GetDiagnoses(int patient_id)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            DataTable dt = dbops.GetDataTable("select * from Diagnoses where patient_id = " + patient_id);
            List<Diagnose> list = new List<Diagnose>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Diagnose entity = Diagnose.fromMap(dt.Rows[i]);
                entity.medicines = MedicineMiddleware.GetMedicines(entity.id);
                list.Add(entity);
            }
            return list;
        }

        public static Diagnose GetDiagnose(int id)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            string query = "select * from Diagnoses where id = " + id + " limit 1";
            DataTable dt = dbops.GetDataTable(query);
            Diagnose entity = Diagnose.fromMap(dt.Rows[0]);
            entity.medicines = MedicineMiddleware.GetMedicines(entity.id);
            return entity;
        }

        public static void SetDiagnose(int id)
        {
            //TODO
        }

        public static void AddDiagnose(int patient_id,Diagnose diagnose)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            string query = "Insert into Diagnoses(patient_id,diagnose,description,exp_date) values(" + patient_id + ",'" +
                diagnose.diagnose + "','" + diagnose.description + "','" + diagnose.exp_date + "')";
            dbops.cmd(query);
        }

        public static void RemoveDiagnose(int id)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            dbops.cmd("delete from Diagnoses where id = " + id);
        }


        public static void RemoveDiagnoses(int patient_id)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            List<Diagnose> diagnoses = GetDiagnoses(patient_id);
            foreach (var elem in diagnoses)
            {
                MedicineMiddleware.RemoveMedicines(elem.id);
                RemoveDiagnose(elem.id);
            }
        }

    }
}
