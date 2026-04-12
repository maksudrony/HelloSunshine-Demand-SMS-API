using System.Data;
using Oracle.ManagedDataAccess.Client;
using HelloSunshineSMSSYNRN_API.Models;

namespace HelloSunshineSMSSYNRN_API.Data
{
    public class OracleRepository
    {
        private readonly string _connectionString;

        public OracleRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleDbContext");
        }

        public async Task<string> InsertUserAsync(UserTestDto user)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand(
                        "INSERT INTO REMOTE_ACC_USER (EMP_ENROLL, EMP_NAME) VALUES (:1, :2)", con))
                    {
                        cmd.Parameters.Add(":1", OracleDbType.Int32).Value = user.EmpEnroll;
                        cmd.Parameters.Add(":2", OracleDbType.Varchar2).Value = user.EmpName;

                        await con.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();

                        return "INSERTED";
                    }
                }
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
    }
}