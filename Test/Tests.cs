using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Service;
using System.Threading.Tasks;

namespace Test
{
    public class Tests
    {
        private IUserService _userService;
        [SetUp]
        public void Setup()
        {
            var serviceProvider = Startup.ServiceProvider;
            if (serviceProvider != null)
            {
                _userService = serviceProvider.GetService<IUserService>();
            }
        }

        [Test]
        public async Task UserServiceAdd_TestAsync()
        {
            var user = new User
            {
                FirstName = "Ahmet",
                MiddleName = "",
                LastName = "Erdoðan"
            };
            var actualResult = await _userService.AddAsync(user);
            var expectedResult = true;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}