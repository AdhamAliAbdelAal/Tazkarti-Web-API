using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TazkartiBusinessLayer.Notifications;
using TazkartiDataAccessLayer.DataTypes;

namespace TazkartiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController: Controller
{
    private readonly IHubContext<NotificationHub> _hubContext;
    public HelloWorldController(IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }
    [HttpGet]
    [Route("admin")]
    [Authorize(Roles = Roles.SiteAdministrator)]
    public ActionResult<string> Admin()
    {
        return Ok("Hello World Admin");
    }
    
    [HttpGet]
    [Route("fan")]
    [Authorize(Roles = Roles.Fan)]
    public ActionResult<string> Fan()
    {
        return Ok("Hello World Fan");
    }
    
    [HttpGet]
    [Route("manager")]
    [Authorize(Roles = Roles.EFAManager)]
    public ActionResult<string> Manager()
    {
        return Ok("Hello World Manager");
    }
    
    [HttpGet]
    [Route("notifier")]
    public async Task<IActionResult> Notifier()
    {
        await _hubContext.Clients.All.SendAsync("ReceiveNotification", "Hello World Notifier");
        return Ok("notified");
    }
}