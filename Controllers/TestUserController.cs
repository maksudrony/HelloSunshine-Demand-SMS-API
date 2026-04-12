using Microsoft.AspNetCore.Mvc;
using HelloSunshineSMSSYNRN_API.Data;
using HelloSunshineSMSSYNRN_API.Models;

namespace HelloSunshineSMSSYNRN_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestUserController : ControllerBase
    {
        private readonly OracleRepository _repo;

        public TestUserController(OracleRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Insert(UserTestDto user)
        {
            var result = await _repo.InsertUserAsync(user);
            return Ok(result);
        }
    }
}