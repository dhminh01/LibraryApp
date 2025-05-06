using LibraryApp.Application.DTOs.Auth;

namespace LibraryApp.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Register(RegisterRequestDto request);
        Task<AuthResponseDto> Login(LoginRequestDto request);
    }
}