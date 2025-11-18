using MiniSocialApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSocialApp.Service
{
    public interface IUserService
    {
        List<User> GetAllUsers();

        User GetUserById(int id);

        void AddUser(User user);

        void UpdateUser(User user,int id);

        void DeleteUser(int id);
    }
}
