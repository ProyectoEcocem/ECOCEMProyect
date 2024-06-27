using ECOCEMProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;


public interface INotificationService
{
    Task<List<Notification>> GetNotificationsAsync(string userId);
    Task CreateNotificationAsync(Notification notification);
    Task MarkAsReadAsync(int notificationId);
}

public class NotificationHub : Hub
{
    private readonly ILogger<NotificationHub> _logger;

    public NotificationHub(ILogger<NotificationHub> logger)
    {
        _logger = logger;
    }

    public override Task OnConnectedAsync()
    {
        _logger.LogInformation($"Client connected: {Context.ConnectionId}");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        _logger.LogInformation($"Client disconnected: {Context.ConnectionId}");
        return base.OnDisconnectedAsync(exception);
    }
}


public class NotificationService : INotificationService
{
    private readonly MyContext _context;
    private readonly IHubContext<NotificationHub> _hubContext;
    private readonly ILogger<NotificationService> _logger;

    public NotificationService(MyContext context, IHubContext<NotificationHub> hubContext, ILogger<NotificationService> logger)
    {
        _context = context;
        _hubContext = hubContext;
        _logger = logger;
    }

    public async Task<List<Notification>> GetNotificationsAsync(string userId)
    {
        _logger.LogInformation($"Fetching notifications for user {userId}");
        return await _context.Notifications.Where(n => n.UserId == userId).ToListAsync();
    }

    public async Task CreateNotificationAsync(Notification notification)
    {
        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Created notification {notification.Id} for user {notification.UserId}");
        await _hubContext.Clients.User(notification.UserId!).SendAsync("ReceiveNotification", notification);
    }

    public async Task MarkAsReadAsync(int notificationId)
    {
        var notification = await _context.Notifications.FindAsync(notificationId);
        if (notification != null)
        {
            notification.IsRead = true;
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Marked notification {notificationId} as read");
        }
    }
}
