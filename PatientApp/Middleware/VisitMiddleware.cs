using PatientApp.Helpers;
using PatientApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PatientApp.Middleware
{
    public static class VisitMiddleware
    {
        public static List<Visit> GetVisits(int patient_id)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            DataTable dt = dbops.GetDataTable("select * from Visits where patient_id = " + patient_id);
            List<Visit> list = new List<Visit>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Visit entity = Visit.fromMap(dt.Rows[i]);
                list.Add(entity);
            }
            return list;
        }

        public static void AddVisit(int patient_id, Visit visit)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            string query = "Insert into Visits(patient_id,description,date) values(" + patient_id + ",'" +
                visit.description + "','" + visit.date + "')";
            dbops.cmd(query);
        }

        public static void RemoveVisit(int id)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            dbops.cmd("delete from Visits where id = " + id);
        }

        public static void RemoveVisits(int patient_id)
        {
            DatabaseOperations dbops = new DatabaseOperations();
            List<Visit> visits = GetVisits(patient_id);
            foreach (var elem in visits)
            {
                RemoveVisit(elem.id);
            }
        }

    }
}
