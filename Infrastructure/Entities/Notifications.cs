using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Notifications
    {
        private Guid Id { get; set; }
        private Guid UserId { get; set; }
        private string Title { get; set; } = string.Empty;
        private string Type { get; set; } = string.Empty;
        private string Message { get; set; } = string.Empty;
        private bool IsRead { get; set; }
        private DateTime ReadAt { get; set; } 
        private DateTime CreatedAt { get; set; }
    }
}
