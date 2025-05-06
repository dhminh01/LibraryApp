using LibraryApp.Domain.Entities;

namespace LibraryApp.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User?> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(Guid id);
    }
}

