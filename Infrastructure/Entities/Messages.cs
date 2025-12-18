using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Messages
    {
        private Guid Id { get; set; }
        private Guid RoomId { get; set; }
        private Guid SenderId { get; set; }
        private Guid ReplyTold { get; set; }
        private string Content { get; set; } = string.Empty;
        private string MessageType { get; set; } = string.Empty;
        private string MetaData { get; set; } = string.Empty;
        private bool Status { get; set; }
        private DateTime CreateAt { get; set; }
        private DateTime UpdateAt { get; set; }
        private bool IsEdited { get; set; }
        private ICollection<MessageAttachments> MessageAttachments { get; set; } = new List<MessageAttachments>();
        private Messages? ReplyMessage { get; set; }
    }
}