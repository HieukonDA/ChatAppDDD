using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MessageAttachments
    {
        private Guid Id { get; set; }
        private Guid MessageId { get; set; }
        private string FileName { get; set; } = string.Empty;
        private string FileType { get; set; } = string.Empty;
        private long FileSize { get; set; }
        private string FileUrl { get; set; } = string.Empty;
        private DateTime UploadedAt { get; set; }
    }
}
