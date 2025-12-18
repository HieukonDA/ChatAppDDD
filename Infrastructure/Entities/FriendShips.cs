using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FriendShips
    {
        private Guid Id { get; set; }
        private Guid UserAId { get; set; }
        private Guid UserBId { get; set; }
        private DateTime CreateAt { get; set; }
    }
}
