using Domain.IdentityContext.UsersAggregates;
using Domain.IdentityContext.ValueObjects;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatAppDbContext _context;

        public UserRepository(ChatAppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetByEmailAsync(Email email)
        {
            return await _context.Users.FirstAsync(u => u.Email == email);
        }

        public async Task<bool> IsEmailExistsAsync(Email email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}
