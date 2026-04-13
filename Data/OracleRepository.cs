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
            _connectionString = configuration.GetConnectionString("OracleDbContext") ?? string.Empty;
        }

        public async Task<string> InsertSmsAsync(SunshineMobileSms_202604 sms)
        {
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("AFML_ERP.SUNSHINE_INSERT_SUNSHINE_MOBILE_SMS_202604", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Mapping the Stored Procedure to your exact Table Column Names
                    cmd.Parameters.Add("P_SMS_SENDER", OracleDbType.Varchar2).Value = sms.SMS_FROM_MOBILE;
                    cmd.Parameters.Add("P_SMS_TEXT", OracleDbType.Varchar2).Value = sms.SMS_TEXT;
                    cmd.Parameters.Add("P_SMS_ID", OracleDbType.Int32).Value = sms.SMS_ID;
                    cmd.Parameters.Add("P_SMS_DATE", OracleDbType.Varchar2).Value = sms.SMS_DEVICE_DATE;
                    cmd.Parameters.Add("P_SMS_FLAG", OracleDbType.Varchar2).Value = sms.READ_FLAG;
                    cmd.Parameters.Add("P_LICENCE_NO", OracleDbType.Varchar2).Value = sms.LICENCE_NO;
                    cmd.Parameters.Add("P_APP_VERSION", OracleDbType.Varchar2).Value = sms.APP_VERSION;

                    OracleParameter outStatus = new OracleParameter("P_STATUS", OracleDbType.Varchar2, 500);
                    outStatus.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outStatus);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return outStatus.Value?.ToString() ?? "Unknown Status";
                }
            }
        }
    }
}