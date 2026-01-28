using AuthServiceRoger.Domain.Entities;
using AuthServiceRoger.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using AuthServiceRoger.Domain.Interfaces;
namespace AuthServiceRoger.Persistence.Repositories;

public class RoleRepository(ApplicationDbContext context) : IRoleRepository
{
    public async Task<Role?> GetByNameAsync(string roleName)
    {
        return await context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
    }

    public async Task<int> CountUsersInRoleAsync(string roleName)
    {
        return await context.UserRoles
            .Include(ur => ur.Role)
            .Where(ur => ur.Role.Name == roleName)
            .Select(ur => ur.Role).Distinct().CountAsync();
    }

    public async Task<IReadOnlyList<User>> GetUsersByRoleAsync(string roleName)
    {
        var users = await context.Users
            .Include(ur => ur.UserProfile)
            .Include(ur => ur.UserEmail)
            .Include(ur => ur.UserRoles)
                .ThenInclude(ur => ur.User)
            .Where(ur => ur.UserRoles.Any(uro => uro.Role.Name == roleName))
            .ToListAsync();
        return users;
    }

    public async Task<IReadOnlyList<string>> GetUserRoleNamesAsync(string userId)
    {
        var roles = await context.UserRoles
            .Include(ur => ur.Role)
            .Where(ur => ur.UserId == userId)
            .Select(ur => ur.Role.Name)
            .ToListAsync();
        return roles;
    }
}