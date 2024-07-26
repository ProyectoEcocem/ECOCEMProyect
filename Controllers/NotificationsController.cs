using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


namespace ECOCEMProject;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly MyContext _context;

    public NotificationController(MyContext db)
    {
        _context = db;
    }

    [HttpPost]
    public async Task<IActionResult> SendNotification([FromBody] NotificationMessage notificationMessage)
    {
        try
        {
            NotificationMessage nm = new NotificationMessage();

            nm.Message = notificationMessage.Message;
            nm.Type = notificationMessage.Type;

            _context.NotificationMessages.Add(nm);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetNotifications()
    {
        try
        {
            var notifications = await _context.NotificationMessages.ToListAsync();
            return Ok(notifications);
        }
        catch
        {
            return BadRequest();
        }
    }
}
