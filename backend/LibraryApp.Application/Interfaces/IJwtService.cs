using LibraryApp.Domain.Entities;

namespace LibraryApp.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}


