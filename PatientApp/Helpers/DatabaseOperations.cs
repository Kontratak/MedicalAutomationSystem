using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;
using System.Data.SQLite;

namespace PatientApp.Helpers
{
    public class DatabaseOperations
    {
        public SQLiteConnection baglan()
        {
            SQLiteConnection baglanti = new SQLiteConnection(@"data source = PatientDB.db");
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();
            return (baglanti);
        }
        public int cmd(string sqlcumle)
        {
            SQLiteConnection baglan = this.baglan();
            SQLiteCommand sorgu = new SQLiteCommand(sqlcumle, baglan);
            int sonuc = 0;
            try
            {
                sonuc = sorgu.ExecuteNonQuery();
            }
            catch (Exception er)
            {

            }
            sorgu.Dispose();
            baglan.Close();
            baglan.Dispose();
            return (sonuc);
        }

        public DataTable GetDataTable(string sql)
        {
            SQLiteConnection baglanti = this.baglan();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, baglanti);
            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
            }
            baglanti.Close();
            baglanti.Dispose();
            return dt;
        }

        public DataRow GetDataRow(string sql)
        {
            DataTable table = GetDataTable(sql);
            if (table.Rows.Count == 0) return null;
            return table.Rows[0];
        }

        public string GetDataCell(string sql)
        {
            DataTable table = GetDataTable(sql);
            if (table.Rows.Count == 0) return null;
            string cell = table.Rows[0][0].ToString();


            return cell;
        }
        public void CloseConnection()
        {
            string constr = "Server=(localdb)\\MSSQLLocalDB;Database=PatientDB;AttachDbFileName=%CONTENTROOTPATH%\\AppData\\PatientDB.mdf;Trusted_Connection=True;MultipleActiveResultSets=true"; //LIVE
            //string constr = "Server=(localdb)\\MSSQLLocalDB;Database=PatientDB;Trusted_Connection=True;MultipleActiveResultSets=true"; //DEBUG
            SqlConnection baglanti = new SqlConnection(constr);
            SqlConnection.ClearPool(baglanti);
            SqlConnection.ClearAllPools();
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
                baglanti.Dispose();
            }
        }

    }
}
