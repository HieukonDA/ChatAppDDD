using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RoomMembers
    {
        private Guid Id { get; set; }
        private Guid RoomId { get; set; }
        private Guid UserId { get; set; }
        private string Role { get; set; } = string.Empty;
        private DateTime JoinedAt { get; set; }
        private DateTime LastSeenAt { get; set; }
        private Guid LastReadMessageId { get; set; }

    }
}
