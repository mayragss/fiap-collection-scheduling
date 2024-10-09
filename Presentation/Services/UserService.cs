using Domain.Entities;
using Infrastructure;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presentation.Interface;
using Presentation.Model;

namespace Presentation.Services;

public class UserService: IUserService
{
    private readonly ICollectionScheduleDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(ICollectionScheduleDbContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task<UserDto> RegisterAsync(string username, string password)
    {
        var user = new User { Username = username };
        user.PasswordHash = _passwordHasher.HashPassword(user, password);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return new(user);
    }

    public async Task<ResponseModel<UserDto>> AuthenticateAsync(string username, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user == null || _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) != PasswordVerificationResult.Success)
        {
            return new("Ocorreu um erro ao validar a senha, tente novamente", false);
        }
        return new(new UserDto(user));
    }
}

