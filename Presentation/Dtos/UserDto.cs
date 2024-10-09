using Domain.Entities;

namespace Presentation.Model;

public class UserDto(User user)
{
    public int Id { get; set; } = user.Id;
    public string Username { get; set; } = user.Username;
    public string Password { get; set; } = user.PasswordHash;
}
