namespace PhotoLib.Application.Authentication.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string email);
}