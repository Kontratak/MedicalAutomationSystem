using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PatientApp.Models
{
    public class Patient
    {

        public int id { get; set; }

        public string name { get; set; }

        public string surname { get; set; }

        public string ssnumber { get; set; }
        public string address { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public int gender { get; set; }
        public string birth_date { get; set; }
        public string age { get; set; }
        public string height { get; set; }
        public string weight { get; set; }

        public List<Diagnose> diagnoses { get; set; }
        public List<Visit> visits { get; set; }


        public Patient(int id, string name, string surname, string ssnumber, string address, string phone_number, string email, string age, string birth_date, int gender, string height, string weight)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.ssnumber = ssnumber;
            this.address = address;
            this.phone_number = phone_number;
            this.email = email;
            this.gender = gender;
            this.birth_date = birth_date;
            this.age = age;
            this.height = height;
            this.weight = weight;
        }
        public Patient(string name, string surname, string ssnumber, string address, string phone_number, string email ,string age, string birth_date, int gender,string height,string weight)
        {
            this.name = name;
            this.surname = surname;
            this.ssnumber = ssnumber;
            this.address = address;
            this.phone_number = phone_number;
            this.email = email;
            this.gender = gender;
            this.birth_date = birth_date;
            this.age = age;
            this.height = height;
            this.weight = weight;
        }

        public static Patient fromMap(DataRow data)
        {
            Patient p = new Patient(int.Parse(data["id"].ToString()), data["name"].ToString(), data["surname"].ToString(),
                data["ss_number"].ToString(), data["address"].ToString(), data["phone_number"].ToString(), data["email"].ToString()
                , data["age"].ToString(), data["birth_date"].ToString(), int.Parse(data["gender"].ToString()), data["height"].ToString(), data["weight"].ToString());
            return p;
        }
    }
}
