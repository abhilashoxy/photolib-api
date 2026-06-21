namespace PhotoLib.Application.Authentication.DTOs;

public record LoginRequest(
    string Email,
    string Password);