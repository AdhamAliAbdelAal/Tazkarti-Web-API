﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TazkartiBusinessLayer.Auth;
using TazkartiBusinessLayer.Handlers;
using TazkartiBusinessLayer.Models;
using TazkartiService.DTOs;

namespace TazkartiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController: Controller
{
    private readonly IMapper _mapper;
    private readonly AuthHandler _authHandler;
    public AuthController(IConfiguration configuration, IMapper mapper, IUserHandler userHandler, AuthHandler authHandler)
    {
        _mapper = mapper;
        _authHandler = authHandler;
    }
    
    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<RegisterResponseDto>> Register([FromBody] RegisterDto request)
    {
        var data = _mapper.Map<RegisterModel>(request);
        var token = await _authHandler.Register(data);
        return Ok(new RegisterResponseDto(token));
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginDto request)
    {
        var data = _mapper.Map<LoginModel>(request);
        var token = await _authHandler.Login(data);
        return Ok(new LoginResponseDto(token));
    }
    
    
}