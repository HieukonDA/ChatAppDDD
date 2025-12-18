using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FriendRequests
    {
        private Guid Id { get; set; }
        private Guid SenderId { get; set; }
        private Guid ReceiverId { get; set; }
        private string Status { get; set; } = string.Empty;
        private DateTime SentAt { get; set; }
        private DateTime? RespondedAt { get; set; }
    }
}
