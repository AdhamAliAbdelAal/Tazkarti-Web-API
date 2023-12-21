using Microsoft.AspNetCore.SignalR;

namespace TazkartiBusinessLayer.Notifications;

public class SeatsNotificationsContext
{
    private readonly IHubContext<NotificationHub> _hubContext;
    
    public SeatsNotificationsContext(IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }
    
    public async Task NotifySeatsReserved(int matchId, int seatId)
    {
        await _hubContext.Clients.All.SendAsync("ReservedSeat", matchId, seatId);
    }

    public async Task NotifySeatsCancelled(int matchId, int seatId)
    {
        await _hubContext.Clients.All.SendAsync("CancelledSeat", matchId, seatId);
    }
}