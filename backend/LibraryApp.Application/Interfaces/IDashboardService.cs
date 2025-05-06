using LibraryApp.Application.DTOs;

namespace LibraryApp.Application.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardStatisticsDto> GetDashboardAsync();
    }
}