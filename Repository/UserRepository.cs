using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUserRepository
    {
        Task<bool> Add(User user);
        Task<bool> Update(User user);
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task<bool> Delete(int id);
    }

    public class UserRepository : IUserRepository
    {

        private readonly OnionDBContext _context;

        public UserRepository(OnionDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var result = await _context.Users.Where(e => e.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.Users.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> GetById(int id)
        {
            var result = await _context.Users.Where(e => e.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<User>> GetAll()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }

    }
}
