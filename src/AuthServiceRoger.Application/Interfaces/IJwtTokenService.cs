using AuthServiceRoger.Domain.Entities;

namespace AuthServiceRoger.Application.DTOs;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}