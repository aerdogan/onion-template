using Domain;
using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        Task<bool> AddAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> AddAsync(User user)
        {
            try
            {
                var obj = new User();
                obj.FirstName = user.FirstName;
                obj.LastName = user.LastName;
                var result = await _userRepository.Add(obj);
                return result;
            }
            catch
            {

                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _userRepository.Delete(id);
                return result;
            }
            catch
            {
                return false;
            }

        }

        public async Task<List<User>> GetAllAsync()
        {
            var userList = new List<User>();
            var result = await _userRepository.GetAll();
            foreach (var item in result)
            {
                userList.Add(new User
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName
                });
            }
            return userList;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var result = await _userRepository.GetById(id);
            var userDM = new User();
            userDM.Id = result.Id;
            userDM.FirstName = result.FirstName;
            userDM.LastName = result.LastName;
            return userDM;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            try
            {
                var obj = new User();
                obj.Id = user.Id;
                obj.FirstName = user.FirstName;
                obj.LastName = user.LastName;
                var result = await _userRepository.Update(obj);
                return result;
            }
            catch
            {
                return false;
            }
        }
    }
}
