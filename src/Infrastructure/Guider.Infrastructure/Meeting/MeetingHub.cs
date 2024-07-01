using Guider.Application.Contracts.Infrastructure;
using Guider.Application.Models.Meeting;
using Guider.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using System.Security.Claims;

namespace Guider.Infrastructure.Meeting
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MeetingHub : Hub<IMeetingClient>, IMeetingService
    {
        private static readonly ConnectionMapping _connections = new ConnectionMapping();


        public override Task OnConnectedAsync()
        {
            var userIdClaim = ((ClaimsIdentity)Context.User.Identity).Claims
                                .FirstOrDefault(e => e.Type.Equals("sid"));

            int userId = int.Parse(userIdClaim.Value);
            _connections.Add(userId, Context.ConnectionId);

            return base.OnConnectedAsync();
        }
        [AllowAnonymous]
        public async Task NotifiyMeetingStart(int clientUserId, int consultantUserId, int appointmentId)
        {
            string? clientConnectionId = _connections.GetConnection(clientUserId);
            string? consultantConnectionId = _connections.GetConnection(consultantUserId);

            if (clientConnectionId != null)
                await Clients.Client(clientConnectionId).MeetingStarted(appointmentId, clientUserId, consultantUserId);

            if (consultantConnectionId != null)
                await Clients.Client(consultantConnectionId).MeetingStarted(appointmentId, clientUserId, consultantUserId);
        }
        public async Task NotifiyMeetingEnd(int clientUserId, int consultantUserId)
        {
            string? clientConnectionId = _connections.GetConnection(clientUserId);
            string? consultantConnectionId = _connections.GetConnection(consultantUserId);

            if (clientConnectionId != null)
                await Clients.Client(clientConnectionId).MeetingClosed();

            if (consultantConnectionId != null)
                await Clients.Client(consultantConnectionId).MeetingClosed();
        }

        public async Task<bool> RequestMeeting(int userId)
        {
            string? connectionId = _connections.GetConnection(userId);

            if (connectionId != null)
            {
                string consultantName = Context.User?.Identity?.Name ?? "";
                await Clients.Client(connectionId).ConsultantRequestMeeting(consultantName);
            }
            return connectionId != null;
        }

        public async Task<bool> JoinMeeting(int userId)
        {
            string? connectionId = _connections.GetConnection(userId);

            if (connectionId != null)
            {
                string clientName = Context.User?.Identity?.Name ?? "";
                await Clients.Client(connectionId).ClientJoined(clientName);
            }
            return connectionId != null;
        }

        public async Task StartMeeting(int userId, string sdp)
        {
            string? connectionId = _connections.GetConnection(userId);

            if (connectionId != null)
            {
                await Clients.Client(connectionId).ConsultantInvite(sdp);
            }
        }

        public async Task SendAnswer(int userId, string sdp)
        {
            string? connectionId = _connections.GetConnection(userId);

            if (connectionId != null)
            {
                await Clients.Client(connectionId).ClientAnswered(sdp);
            }
        }

        public async Task AddCandidate(int userId, IceCandidate candidate)
        {
            string? connectionId = _connections.GetConnection(userId);

            if (connectionId != null)
            {
                await Clients.Client(connectionId).ReceiveCandidate(candidate);
            }

        }

        public async Task<bool> SendMessage(int userId, string msg)
        {
            string? connectionId = _connections.GetConnection(userId);

            if (connectionId != null)
            {
                string senderName = Context.User?.Identity?.Name ?? "";
                await Clients.Client(connectionId).ReceiveMessage(senderName,msg);
                return true;
            }
            return false;
        }

        public async Task CloseMeeting(int userId)
        {
            string? connectionId = _connections.GetConnection(userId);

            if (connectionId != null)
            {
                await Clients.Client(connectionId).MeetingClosed();
            }
        }
        

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var userIdClaim = ((ClaimsIdentity)Context.User.Identity).Claims
                                .FirstOrDefault(e => e.Type.Equals("sid"));

            int userId = int.Parse(userIdClaim.Value);

            _connections.Remove(userId);

            return base.OnDisconnectedAsync(exception);
        }

    }
}
