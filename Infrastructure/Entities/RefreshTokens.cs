using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RefreshTokens
    {
        private Guid Id { get; set; }
        private Guid UserId { get; set; }
        private string Token { get; set; } = string.Empty;
        private string DeviceId { get; set; } = string.Empty;
        private DateTime ExpiresAt { get; set; }
        private DateTime CreatedAt { get; set; }
        private bool IsRevoked { get; set; }
    }
}
