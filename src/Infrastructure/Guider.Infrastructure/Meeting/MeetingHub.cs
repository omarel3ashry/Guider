﻿using Guider.Application.Contracts.Infrastructure;
using Guider.Application.Models.Meeting;
using Guider.Identity.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.Intrinsics.Arm;
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
                                .FirstOrDefault(e => e.Type.Equals(PolicyData.IdClaimName));

            int userId = int.Parse(userIdClaim.Value);
            _connections.Add(userId, Context.ConnectionId);

            return base.OnConnectedAsync();
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

        public async Task SendMessage(int userId, string msg)
        {
            string? connectionId = _connections.GetConnection(userId);

            if (connectionId != null)
            {
                await Clients.Client(connectionId).ReceiveMessage(msg);
            }
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
                                .FirstOrDefault(e => e.Type.Equals(PolicyData.IdClaimName));

            int userId = int.Parse(userIdClaim.Value);

            _connections.Remove(userId);

            return base.OnDisconnectedAsync(exception);
        }

    }
}