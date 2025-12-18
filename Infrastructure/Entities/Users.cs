using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Users
    {
        private Guid Id { get; set; }
        private string Email { get; set; } = string.Empty;
        private string UserName { get; set; } = string.Empty;
        private string PasswordHash { get; set; } = string.Empty;
        private string AvatarUrl { get; set; } = string.Empty;
        private string Status { get; set; } = string.Empty;
        private DateTime CreatedAt { get; set; }
        private DateTime UpdatedAt { get; set; }
        private DateTime LastSeenAt { get; set; }
        private ICollection<RefreshTokens> RefreshTokens { get; set; } = new List<RefreshTokens>();
        private ICollection<Messages> Messages { get; set; } = new List<Messages>();
        private ICollection<Notifications> Notifications { get; set; } = new List<Notifications>();
        private ICollection<RoomMembers> RoomMembers { get; set; } = new List<RoomMembers>();
        private ICollection<FriendRequests> FriendRequests { get; set; } = new List<FriendRequests>();
        private ICollection<FriendShips> FriendShips { get; set; } = new List<FriendShips>();

    }
}
