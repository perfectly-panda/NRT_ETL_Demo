using Microsoft.AspNetCore.SignalR;
using Models;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class TruckHub : Hub
    {
        public async Task SendMessage(int truckId, Truck truck)
        {
            await Clients.All.SendAsync("TruckUpdate", truckId, truck);
        }
    }
}