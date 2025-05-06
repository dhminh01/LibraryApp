using AutoMapper;
using LibraryApp.Application.DTOs.User;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto?> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto?> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.GetUserByIdAsync(updateUserDto.Id);
            if (user == null)

                return null;

            var existingPassword = user.PasswordHash;

            _mapper.Map(updateUserDto, user);
            user.PasswordHash = existingPassword;
            user.UpdatedAt = DateTime.UtcNow;

            var updatedUser = await _userRepository.UpdateUserAsync(user);

            return _mapper.Map<UserDto>(updatedUser);
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }
    }
}