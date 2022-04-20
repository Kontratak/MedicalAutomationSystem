using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PatientApp.Models
{
    public class Visit
    {

        public int id { get; set; }
        public int patient_id { get; set; }
        public string description { get; set; }

        public string date { get; set; }

        public Visit(int id, int patient_id, string description, string date)
        {
            this.id = id;
            this.patient_id = patient_id;
            this.description = description;
            this.date = date;
        }
        public Visit(int patient_id,string description, string date)
        {
            this.patient_id = patient_id;
            this.description = description;
            this.date = date;
        }

        public static Visit fromMap(DataRow data)
        {
            Visit d = new Visit(int.Parse(data["id"].ToString()), int.Parse(data["patient_id"].ToString()),  data["description"].ToString(), data["date"].ToString());
            return d;
        }


    }
}
