using System;
using System.Collections.Generic;
using System.Text;

namespace APB.AccessControl.Application.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(string username, IEnumerable<string> roles);
    }
}
