using Microsoft.AspNetCore.SignalR;

namespace Guider.WebApi.Hubs
{
    public class MeetingHub : Hub
    {
        private readonly ILogger _logger;

        public MeetingHub(ILogger<MeetingHub> logger)
        {
            _logger = logger;
        }

        public async Task RequestMeeting(int id, string sdp)
        {
            _logger.LogInformation(sdp);
            await Clients.Others.SendAsync("ConsultantInvite", Context.ConnectionId, sdp);
        }

        public async Task SendAnswer(int id, string sdp)
        {
            await Clients.Others.SendAsync("ClientAnswered", Context.ConnectionId, sdp);
        }

        public async Task AddCandidate(int id, IceCandidate candidate)
        {
            await Clients.Others.SendAsync("ReceiveCandidate", Context.ConnectionId, candidate);
        }

        public async Task CloseMeeting(int id)
        {
            await Clients.Others.SendAsync("MeetingClosed", Context.ConnectionId);
        }
    }
}
