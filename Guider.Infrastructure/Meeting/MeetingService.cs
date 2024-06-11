using Guider.Application.Contracts.Infrastructure;
using Guider.Application.Models.Meeting;

namespace Guider.Infrastructure.Meeting
{
    public class MeetingService : IMeetingService
    {
        public Task AddCandidate(int id, IceCandidate candidate)
        {
            throw new NotImplementedException();
        }

        public Task CloseMeeting(int id)
        {
            throw new NotImplementedException();
        }

        public Task RequestMeeting(int id, string sdp)
        {
            throw new NotImplementedException();
        }

        public Task SendAnswer(int id, string sdp)
        {
            throw new NotImplementedException();
        }
    }
}
