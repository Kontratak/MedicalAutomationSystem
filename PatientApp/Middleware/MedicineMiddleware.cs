using PatientApp.Helpers;
using PatientApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PatientApp.Middleware
{
    public static class MedicineMiddleware
    {
        public static List<Medicine> GetMedicines(int diagnose_id)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            DataTable dt = dbops.GetDataTable("select * from Medicine where diagnose_id = " + diagnose_id);
            List<Medicine> list = new List<Medicine>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Medicine entity = Medicine.fromMap(dt.Rows[i]);
                list.Add(entity);
            }
            return list;
        }

        public static Medicine GetMedicine(int id)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            string query = "select * from Medicine where id = " + id + " limit 1";
            DataTable dt = dbops.GetDataTable(query);
            Medicine entity = Medicine.fromMap(dt.Rows[0]);
            return entity;
        }

        public static void SetMedicine(int id)
        {
            //TODO
        }

        public static void AddMedicine(int diagnose_id,Medicine medicine)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            string query = "Insert into Medicine(diagnose_id,med_name,usage,description,exp_date) values(" + diagnose_id + ",'" +
                medicine.name + "','" + medicine.usage + "','" + medicine.description + "','" + medicine.exp_date + "')";
            dbops.cmd(query);
        }

        public static void RemoveMedicine(int id)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            dbops.cmd("delete from Medicine where id = " + id);
        }

        public static void RemoveMedicines(int diagnose_id)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            List<Medicine> medicines = GetMedicines(diagnose_id);
            foreach (var elem in medicines)
            {
                RemoveMedicine(elem.id);
            }
        }
    }
}
