using Guider.Application.Models.Meeting;

namespace Guider.Application.Contracts.Infrastructure
{
    public interface IMeetingService
    {
        public Task RequestMeeting(int userId, string sdp);

        public Task SendAnswer(int userId, string sdp);

        public Task AddCandidate(int userId, IceCandidate candidate);

        public Task CloseMeeting(int userId);
    }
}
