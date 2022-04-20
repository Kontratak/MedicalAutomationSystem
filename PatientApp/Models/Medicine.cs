using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PatientApp.Models
{
    public class Medicine
    {
        public int id { get; set; }
        public int diagnose_id { get; set; }

        public string name { get; set; }

        public string exp_date { get; set; }
        public string description { get; set; }

        public string usage { get; set; }


        Medicine(int id, int diagnose_id, string name, string description, string usage,string exp_date)
        {
            this.id = id;
            this.diagnose_id = diagnose_id;
            this.name = name;
            this.exp_date = exp_date;
            this.description = description;
            this.usage = usage;
        }

        public Medicine(int diagnose_id, string name, string description, string usage,string exp_date)
        {
            this.diagnose_id = diagnose_id;
            this.name = name;
            this.exp_date = exp_date;
            this.description = description;
            this.usage = usage;
        }

        public static Medicine fromMap(DataRow data)
        {
            Medicine d = new Medicine(int.Parse(data["id"].ToString()), int.Parse(data["diagnose_id"].ToString()), data["med_name"].ToString(), data["description"].ToString(), data["usage"].ToString(), data["exp_date"].ToString());
            return d;
        }
    }
}
