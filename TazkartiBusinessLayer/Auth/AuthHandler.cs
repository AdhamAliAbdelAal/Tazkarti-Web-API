using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TazkartiBusinessLayer.Handlers;
using TazkartiBusinessLayer.Models;

namespace TazkartiBusinessLayer.Auth;

public class AuthHandler
{
    private readonly IConfiguration _configuration;
    private readonly IUserHandler _userHandler;
    
    public AuthHandler(IConfiguration configuration, IUserHandler userHandler)
    {
        _configuration = configuration;
        _userHandler = userHandler;
    }
    private string GenerateJwtToken(UserModel user)
    {
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]??string.Empty));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>()
        {
            // sub is the subject of the token, which is the user that the token represents
            new Claim("sub", user.Username),
            
            // add role claim based on the user role
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            
            new Claim("username", user.Username),
            
        };
        var token = new JwtSecurityToken(
            _configuration["Authentication:Issuer"],
            _configuration["Authentication:Audience"],
            claims,
            DateTime.Now,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
        );
        string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }
    
    public async Task<string?> Register(RegisterModel data)
    {
        data.Password = PasswordHasherUtility.HashPassword(data.Password);
        var user = await _userHandler.Register(data);
        if (user == null)
        {
            return null;
        }
        var token = GenerateJwtToken(user);
        return token;
    }
    
    public async Task<string?> Login(LoginModel data)
    {
        var user = await _userHandler.GetUserByUsername(data.Username);
        if (user == null||PasswordHasherUtility.VerifyPassword(user.Password, data.Password)== PasswordVerificationResult.Failed)
        {
            return null;
        }
        var token = GenerateJwtToken(user);
        return token;
    }
}