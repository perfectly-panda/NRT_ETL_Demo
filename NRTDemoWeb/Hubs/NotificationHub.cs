using Microsoft.AspNetCore.SignalR;
using Models;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("Notification", message);
        }
    }
}