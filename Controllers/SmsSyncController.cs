using Microsoft.AspNetCore.Mvc;
using HelloSunshineSMSSYNRN_API.Models;
using HelloSunshineSMSSYNRN_API.Services;

namespace HelloSunshineSMSSYNRN_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsSyncController : ControllerBase
    {
        private readonly ISmsSyncService _smsSyncService;

        public SmsSyncController(ISmsSyncService smsSyncService)
        {
            _smsSyncService = smsSyncService;
        }

        [HttpPost("sync")]
        public async Task<IActionResult> SyncSms([FromBody] List<SunshineMobileSms_202604> smsList)
        {
            if (smsList == null || smsList.Count == 0)
                return BadRequest(new SyncResponse { Success = false, Message = "No data received." });

            var response = await _smsSyncService.ProcessSmsBatchAsync(smsList);
            return Ok(response);
        }
    }
}