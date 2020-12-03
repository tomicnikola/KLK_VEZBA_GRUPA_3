using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class VetRepository
    {

        public List<Vet> GetAllVets()
        {
            List<Vet> v = new List<Vet>();

            using (SqlConnection con = new SqlConnection(Constants.conString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "SELECT * FROM Vets";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    Vet item = new Vet();
                    item.Id = dr.GetInt32(0);
                    item.FullName = dr.GetString(1);
                    item.Specialty = dr.GetString(2);
                    item.YearsExperience = dr.GetInt32(3);

                    v.Add(item);

                }

                return v;

            }
        }

        public int InsertVet(Vet v)
        {
            int result;
            using (SqlConnection con = new SqlConnection(Constants.conString))
            {
                string commandText = string.Format("INSERT INTO Vets VALUES( '{0}', '{1}', {2})", v.FullName, v.Specialty, v.YearsExperience);
                SqlCommand com = new SqlCommand(commandText, con);

                con.Open();
                result = com.ExecuteNonQuery();
            }

            return result;
        }

        public int UpdateVet(Vet v, int id)
        {
            int result;
            using (SqlConnection con = new SqlConnection(Constants.conString))
            {
                string commandText = string.Format("UPDATE Vets SET Fullname = '{0}', Specialty = '{1}', YearsExperience = {2}" +
                    "WHERE Id = {3} ", v.FullName, v.Specialty, v.YearsExperience, id);
                SqlCommand com = new SqlCommand(commandText, con);

                con.Open();
                result = com.ExecuteNonQuery();
            }

            return result;
        }

        public int DeleteVet(int id)
        {
            int result;
            using (SqlConnection con = new SqlConnection(Constants.conString))
            {
                string commandText = string.Format("DELETE FROM Vets Where Id = {0}", id);
                SqlCommand com = new SqlCommand(commandText, con);

                con.Open();
                result = com.ExecuteNonQuery();
            }

            return result;
        }


    }
}
