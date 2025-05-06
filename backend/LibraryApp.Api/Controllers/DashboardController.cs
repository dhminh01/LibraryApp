using LibraryApp.Application.Interfaces;
using LibraryApp.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace LibraryApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public async Task<ActionResult<DashboardStatisticsDto>> GetDashboard()
        {
            var result = await _dashboardService.GetDashboardAsync();

            return Ok(result);
        }
    }
}
