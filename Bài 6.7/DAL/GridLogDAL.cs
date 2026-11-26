using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class GridLogDAL
    {
        public void InsertOverloadLog(GridTelemetryDTO data, string warningMsg)
        {
            string query = @"
                INSERT INTO OverloadLogs (SubstationCode, RecordedTime, VoltageKV, LoadPercent, WarningMessage)
                VALUES (@Code, @Time, @Volt, @Load, @Msg)";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Code", data.SubstationCode);
                    cmd.Parameters.AddWithValue("@Time", data.Timestamp);
                    cmd.Parameters.AddWithValue("@Volt", data.VoltageKV);
                    cmd.Parameters.AddWithValue("@Load", data.LoadPercent);
                    cmd.Parameters.AddWithValue("@Msg", warningMsg);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}