using ToDoApi.DTOs;

namespace ToDoApi.Services;

public interface IAuthService
{
    Task<string> RegisterUserAsync(RegisterDto registerDto);
    Task<string> LoginUserAsync(LoginDto loginDto);
}