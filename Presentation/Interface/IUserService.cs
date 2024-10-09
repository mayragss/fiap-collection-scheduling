using Domain.Entities;
using Presentation.Model;

namespace Presentation.Interface;

public interface IUserService
{
    Task<UserDto> RegisterAsync(string username, string password);
    Task<ResponseModel<UserDto>> AuthenticateAsync(string username, string password);
}
