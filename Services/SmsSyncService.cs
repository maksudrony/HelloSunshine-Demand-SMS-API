using HelloSunshineSMSSYNRN_API.Models;
using HelloSunshineSMSSYNRN_API.Data;

namespace HelloSunshineSMSSYNRN_API.Services
{
    public class SmsSyncService : ISmsSyncService
    {
        private readonly OracleRepository _repository;

        public SmsSyncService(OracleRepository repository)
        {
            _repository = repository;
        }

        public async Task<SyncResponse> ProcessSmsBatchAsync(List<SunshineMobileSms_202604> smsList)
        {
            int successCount = 0;
            string lastMessage = string.Empty;

            foreach (var sms in smsList)
            {
                try
                {
                    string result = await _repository.InsertSmsAsync(sms);
                    if (result == "INSERTED") successCount++;
                    lastMessage = result;
                }
                catch (Exception ex)
                {
                    lastMessage = $"Exception: {ex.Message}";
                }
            }

            return new SyncResponse
            {
                Success = successCount > 0,
                Message = $"Inserted: {successCount}. Last Status: {lastMessage}"
            };
        }
    }
}