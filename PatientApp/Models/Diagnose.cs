using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PatientApp.Models
{
    public class Diagnose
    {
        public int id { get; set; }
        public int patient_id { get; set; }

        public string diagnose { get; set; }

        public string description { get; set; }

        public string exp_date { get; set; }

        public List<Medicine> medicines { get; set; }

        public Diagnose(int id,int patient_id, string diagnose, string description, string exp_date)
        {
            this.id = id;
            this.patient_id = patient_id;
            this.diagnose = diagnose;
            this.description = description;
            this.exp_date = exp_date;
        }
        public Diagnose(int patient_id, string diagnose, string description, string exp_date)
        {
            this.patient_id = patient_id;
            this.diagnose = diagnose;
            this.description = description;
            this.exp_date = exp_date;
        }

        public static Diagnose fromMap(DataRow data)
        {
            Diagnose d = new Diagnose(int.Parse(data["id"].ToString()), int.Parse(data["patient_id"].ToString()), data["diagnose"].ToString(), data["description"].ToString(), data["exp_date"].ToString());
            return d;
        }
    }
}
