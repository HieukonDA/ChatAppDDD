using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rooms
    {
        private Guid Id { get; set; }
        private Guid OwnerId { get; set; }
        private string? Name { get; set; } = string.Empty;
        private string RoomType { get; set; } = string.Empty;
        private string Description { get; set; } = string.Empty;
        private string? AvatarUrl { get; set; } = string.Empty;
        private int MemberCount { get; set; }
        private int Version { get; set; }
        private DateTime LastMessageAt { get; set; }
        private DateTime CreatedAt { get; set; }
        private DateTime UpdatedAt { get; set; }
        private ICollection<RoomMembers> RoomMembers { get; set; } = new List<RoomMembers>();
        private ICollection<Messages> Messages { get; set; } = new List<Messages>();
    }
}
