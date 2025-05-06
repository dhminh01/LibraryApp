using LibraryApp.Application.DTOs.User;
using LibraryApp.Domain.Entities;

namespace LibraryApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(Guid id);
        Task<UserDto?> UpdateUserAsync(UpdateUserDto updateUserDto);
        Task<bool> DeleteUserAsync(Guid id);
    }
}