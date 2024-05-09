using MainPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage.Services
{
    public interface ILoginRespository
    {
        Task<UserInfo> Login(string username, string password);

    }

    public class LoginRepository : ILoginRespository
    {
        public Task<UserInfo> Login(string username, string password)
        {
            var userInfo = new UserInfo
            {
                UserId = "123",
                UserName = username,
                Password = password
            };

            return Task.FromResult(userInfo);
        }
    }
}
