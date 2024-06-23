using Guider.Application.Models.Meeting;

namespace Guider.Application.Contracts.Infrastructure
{
    public interface IMeetingService
    {
        public Task<bool> RequestMeeting(int userId);

        public Task<bool> JoinMeeting(int userId);

        public Task StartMeeting(int userId, string sdp);

        public Task SendAnswer(int userId, string sdp);

        public Task AddCandidate(int userId, IceCandidate candidate);

        public Task<bool> SendMessage(int userId, string msg);

        public Task CloseMeeting(int userId);
    }
}
