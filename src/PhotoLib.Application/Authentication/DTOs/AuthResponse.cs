using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoLib.Application.Authentication.DTOs
{
    public record AuthResponse(
     string Token,
     string Email);
}
