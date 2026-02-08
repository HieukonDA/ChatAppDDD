using Domain.IdentityContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdentityContext.UsersAggregates
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<bool> IsEmailExistsAsync(Email email);
        Task<User> GetByEmailAsync(Email email);
    }
}
