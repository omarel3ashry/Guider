using Guider.Application.Models.Meeting;

namespace Guider.Application.Contracts.Infrastructure
{
    public interface IMeetingClient
    {
        Task MeetingStarted(int appointmentId, int clientUserId, int consultantUserId);
        Task ConsultantRequestMeeting(string consultantName);
        Task ClientJoined(string clientName);
        Task ConsultantInvite(string sdp);
        Task ClientAnswered(string sdp);
        Task ReceiveCandidate(IceCandidate candidate);
        Task ReceiveMessage(string msg);
        Task MeetingClosed();
    }
}
