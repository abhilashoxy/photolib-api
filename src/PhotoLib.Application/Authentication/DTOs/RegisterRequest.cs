namespace PhotoLib.Application.Authentication.DTOs;

public record RegisterRequest(
    string Email,
    string Password,
    string FirstName,
    string LastName);