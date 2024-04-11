using Microsoft.Data.SqlClient;

namespace TrainingFPTCo.Models.Queries
{
    public class RoleQuery
    {
        public List<RoleDetail> GetAllDataRole()
        {
            List<RoleDetail> roles = new List<RoleDetail>();
            using (SqlConnection connection = Database.GetSqlConnection())
            {
                string sql = "SELECT * FROM [Roles] WHERE [DeletedAt] IS NULL";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RoleDetail detail = new RoleDetail();
                        detail.Id = Convert.ToInt32(reader["Id"]);
                        detail.Name = reader["Name"].ToString() ?? DBNull.Value.ToString();
                        detail.Status = reader["Status"].ToString() ?? DBNull.Value.ToString();
                        roles.Add(detail);
                    }
                    connection.Close();
                }
            }
            return roles;
        }
    }
}
