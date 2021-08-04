using Microsoft.EntityFrameworkCore;
using Repository.DB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUserRepository
    {
        Task<bool> Add(TblUser user);
        Task<bool> Update(TblUser user);
        Task<List<TblUser>> GetAll();
        Task<TblUser> GetById(int id);
        Task<bool> Delete(int id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly OnionDBContext _context;
        public UserRepository(OnionDBContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(TblUser user)
        {
            try
            {
                await _context.TblUser.AddAsync(user);
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
                var result = await _context.TblUser.Where(e => e.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.TblUser.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<TblUser>> GetAll()
        {
            var result = await _context.TblUser.ToListAsync();
            return result;
        }

        public async Task<TblUser> GetById(int id)
        {
            var result = await _context.TblUser.Where(e => e.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> Update(TblUser user)
        {
            try
            {
                _context.TblUser.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
