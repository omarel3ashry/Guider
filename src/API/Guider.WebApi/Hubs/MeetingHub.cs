using Microsoft.AspNetCore.SignalR;

namespace Guider.WebApi.Hubs
{
    public class MeetingHub : Hub
    {
        public async Task RequestMeeting(string id, string data)
        {
            await Clients.Others.SendAsync("ConsultantInvite", Context.ConnectionId, data);
        }

        public async Task SendAnswer(string id, string data)
        {
            await Clients.Others.SendAsync("ClientAnswered", Context.ConnectionId, data);
        }

        public async Task CloseMeeting(string id)
        {
            await Clients.Others.SendAsync("MeetingClosed", Context.ConnectionId);
        }
    }
}
