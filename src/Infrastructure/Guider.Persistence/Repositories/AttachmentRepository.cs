using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Persistence.Repositories
{
    public class AttachmentRepository : BaseRepository<Attachment>,IAttachmentRepository
    {
        public AttachmentRepository(GuiderContext context) :base(context){}

        public async Task<bool> AddAttachmentsAsync(List<Attachment> attachments)
        {
            await _context.Attachments.AddRangeAsync(attachments);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
