using Guider.Application.Models.Meeting;

namespace Guider.Application.Contracts.Infrastructure
{
    public interface IMeetingClient
    {
        Task ConsultantInvite(string sdp);
        Task ClientAnswered(string sdp);
        Task ReceiveCandidate(IceCandidate candidate);
        Task ClientUnreachable();
        Task MeetingClosed();
    }
}
