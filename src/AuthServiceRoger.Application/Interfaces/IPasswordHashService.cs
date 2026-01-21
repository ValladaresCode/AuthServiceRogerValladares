namespace AuthServiceRoger.Application.DTOs;

public interface IPasswordHashService
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string phashedPassword);
}