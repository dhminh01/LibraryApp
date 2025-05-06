using LibraryApp.Domain.Entities;

namespace LibraryApp.Domain.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> GetByUserNameAsync(string username);
        Task<bool> UserNameExistsAsync(string username);
        Task<bool> EmailExistsAsync(string email);
        Task AddUserAsync(User user);
    }
}
