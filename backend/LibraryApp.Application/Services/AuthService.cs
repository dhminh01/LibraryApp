using LibraryApp.Application.Common;
using LibraryApp.Application.DTOs.Auth;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly JwtService _jwtService;

        public AuthService(IAuthRepository authRepository, JwtService jwtService)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
        }

        public async Task<AuthResponseDto> Register(RegisterRequestDto request)
        {
            if (await _authRepository.UserNameExistsAsync(request.UserName))
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Username already exists"
                };
            }

            if (await _authRepository.EmailExistsAsync(request.Email))
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Email already exists"
                };
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email,
                PasswordHash = PasswordHasher.HashPassword(request.Password),
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                DateOfBirth = request.DateOfBirth,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true
            };

            await _authRepository.AddUserAsync(user);

            var token = _jwtService.GenerateToken(user);

            return new AuthResponseDto
            {
                Success = true,
                Message = "Registration successful",
                Token = token,
                TokenExpiration = DateTime.Now.AddHours(3)
            };
        }

        public async Task<AuthResponseDto> Login(LoginRequestDto request)
        {
            var user = await _authRepository.GetByUserNameAsync(request.UserName);

            if (user == null || !VerifyPassword(request.Password, user.PasswordHash))
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Invalid username or password"
                };
            }

            if (!user.IsActive)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Account is deactivated"
                };
            }

            var token = _jwtService.GenerateToken(user);

            return new AuthResponseDto
            {
                Success = true,
                Message = "Login successful",
                Token = token,
                Role = user.Role,
                TokenExpiration = DateTime.Now.AddHours(3)
            };
        }

        private static bool VerifyPassword(string password, string hash)
        {
            return PasswordHasher.HashPassword(password) == hash;
        }
    }
}