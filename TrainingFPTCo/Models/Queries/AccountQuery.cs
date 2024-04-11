using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TrainingFPTCo.Models.Queries
{
    public class AccountQuery
    {
        public int InsertAccount(
           int roleId,
           string? userName,
           string? password,
           string extraCode,
           string? email,
           string? phone,
           string address,
           string? fullName,
           string firstName,
           string lastName,
           DateTime birthday,
           string gender
        )
        {
            int IdUser = 0;
            using (SqlConnection connection = Database.GetSqlConnection())
            {
                string sqlQuery = "INSERT INTO [Users] ([RolesId], [Username], [Password],[ExtraCode], [Email], [Phone], [Address],[FullName],[FirstName],[LastName],[Birthday],[Gender], [CreatedAt]) VALUES  (@RoleId, @Username, @Password, @ExtraCode, @Email, @Phone,@Address,@FullName,@FirstName,@LastName,@Birthday,@Gender, @CreatedAt); SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@RoleId", roleId);
                cmd.Parameters.AddWithValue("@Username", userName ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@Password", password ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@ExtraCode", extraCode);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@FullName", fullName ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Birthday", birthday);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                IdUser = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
            }
            return IdUser;
        }
        public bool DeleteCourseById(int id)
        {
            bool checkDelete = false;
            using (SqlConnection connection = Database.GetSqlConnection())
            {
                string sqlQuery = "UPDATE [Users] SET [DeletedAt] = @DeletedAt WHERE [Id] = @id";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@DeletedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                checkDelete = true;
                connection.Close();
            }
            return checkDelete;
        }
        public AccountDetail GetDetailAccountById(int id)
        {
            AccountDetail detail = new AccountDetail();
            using (SqlConnection connection = Database.GetSqlConnection())
            {
                string sql = "SELECT * FROM [Users] WHERE [Id] = @id AND [DeletedAt] IS NULL";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        detail.Id = Convert.ToInt32(reader["Id"]);
                        detail.RoleId = Convert.ToInt32(reader["RolesId"]);
                        detail.UserName = reader["UserName"].ToString() ?? DBNull.Value.ToString();
                        detail.Password = reader["Password"].ToString() ?? DBNull.Value.ToString();
                        detail.ExtraCode = reader["ExtraCode"].ToString();
                        detail.Email = reader["Email"].ToString() ?? DBNull.Value.ToString();
                        detail.Phone = reader["Phone"].ToString() ?? DBNull.Value.ToString();
                        detail.Address = reader["Address"].ToString();
                        detail.FullName = reader["FullName"].ToString() ?? DBNull.Value.ToString();
                        detail.FirstName = reader["FirstName"].ToString();
                        detail.LastName = reader["LastName"].ToString();
                        detail.BirthDay = (DateTime)reader["Birthday"];
                        detail.Gender = reader["Gender"].ToString();
                    }
                }
                connection.Close();
            }
            return detail;
        }
        public List<AccountDetail> GetAllDataAccount()
        {
            List<AccountDetail> courses = new List<AccountDetail>();
            using (SqlConnection connection = Database.GetSqlConnection())
            {
                string sql = "SELECT * FROM [Users] WHERE [DeletedAt] IS NULL";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AccountDetail detail = new AccountDetail();
                        detail.Id = Convert.ToInt32(reader["Id"]);
                        detail.RoleId = Convert.ToInt32(reader["RolesId"]);
                        detail.UserName = reader["UserName"].ToString() ?? DBNull.Value.ToString();
                        detail.Password = reader["Password"].ToString() ?? DBNull.Value.ToString();
                        detail.ExtraCode = reader["ExtraCode"].ToString();
                        detail.Email = reader["Email"].ToString() ?? DBNull.Value.ToString();
                        detail.Phone = reader["Phone"].ToString() ?? DBNull.Value.ToString();
                        detail.Address = reader["Address"].ToString();
                        detail.FullName = reader["FullName"].ToString() ?? DBNull.Value.ToString();
                        detail.FirstName = reader["FirstName"].ToString();
                        detail.LastName = reader["LastName"].ToString();
                        detail.BirthDay = Convert.ToDateTime(reader["Birthday"]);
                        detail.Gender = reader["Gender"].ToString();
                        courses.Add(detail);
                    }
                    connection.Close();
                }
            }
            return courses;
        }
        public bool UpdateAccountById(
           int id,
           int roleId,
           string? userName,
           string? password,
           string extraCode,
           string? email,
           string? phone,
           string address,
           string? fullName,
           string firstName,
           string lastName,
           DateTime birthday,
           string gender

           )
        {
            bool checkUpdate = false;
            using (SqlConnection connection = Database.GetSqlConnection())
            {
                string sql = "UPDATE [Users] SET [RolesId] = @RoleId, [UserName] = @UserName, [Password] = @Password, [ExtraCode] = @ExtraCode, [Email] = @Email, [Phone] = @Phone, [Address] = @Address, [FullName] = @FullName, [FirstName] = @FirstName, [LastName] = @LastName, [Birthday] = @Birthday, [Gender] = @Gender, [UpdatedAt] = @UpdatedAt WHERE [Id] = @Id AND [DeletedAt] IS NULL";
                
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@RoleId", roleId);
                cmd.Parameters.AddWithValue("@Username", userName ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@Password", password ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@ExtraCode", extraCode);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@FullName", fullName ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Birthday", birthday);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                
                cmd.ExecuteNonQuery();
                checkUpdate = true;
                connection.Close();
            }
            return checkUpdate;
        }
    }
}
