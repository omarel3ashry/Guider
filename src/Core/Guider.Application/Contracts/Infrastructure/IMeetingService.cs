using Guider.Application.Models.Meeting;

namespace Guider.Application.Contracts.Infrastructure
{
    public interface IMeetingService
    {
        public Task RequestMeeting(int id, string sdp);

        public Task SendAnswer(int id, string sdp);

        public Task AddCandidate(int id, IceCandidate candidate);

        public Task CloseMeeting(int id);
    }
}
