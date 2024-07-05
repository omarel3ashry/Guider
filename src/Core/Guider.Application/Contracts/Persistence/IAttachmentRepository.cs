using Guider.Domain.Entities;

namespace Guider.Application.Contracts.Persistence
{
    public interface IAttachmentRepository
    {
        Task<bool> AddAttachmentsAsync(List<Attachment> attachments);
    }
}
