using AuthServiceRoger.Application.DTOs;
namespace AuthServiceRoger.Application.DTOs;

public interface IUserManagementService
{
    Task<UserResponseDto> UpdateUserRoleAsync(string userId, string roleName);

    Task<IReadOnlyList<string>> GetUserRolesAsync(string userId);
    Task<IReadOnlyList<UserResponseDto>> GetUserByRoleAsync(string roleName);
}