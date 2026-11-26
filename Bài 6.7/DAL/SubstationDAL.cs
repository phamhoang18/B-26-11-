using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class SubstationDAL
    {
        public List<SubstationDTO> GetAllSubstations()
        {
            var list = new List<SubstationDTO>();
            string query = "SELECT SubstationCode, SubstationName, NominalVoltageKV FROM Substations";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SubstationDTO
                        {
                            SubstationCode = reader["SubstationCode"].ToString(),
                            SubstationName = reader["SubstationName"].ToString(),
                            NominalVoltageKV = Convert.ToDouble(reader["NominalVoltageKV"])
                        });
                    }
                }
            }
            return list;
        }
    }
}