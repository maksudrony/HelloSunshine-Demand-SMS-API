using HelloSunshineSMSSYNRN_API.Models;

namespace HelloSunshineSMSSYNRN_API.Services
{
    public interface ISmsSyncService
    {
        Task<SyncResponse> ProcessSmsBatchAsync(List<SunshineMobileSms_202604> smsList);
    }
}