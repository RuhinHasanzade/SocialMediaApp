using MiniSocialApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSocialApp.Service.Impl
{
    class UserServiceImpl : IUserService
    {
        private readonly string _filePth;

        public UserServiceImpl(string filePth)
        {
            _filePth = filePth;
        }


        private List<User> ReaderAllUsers()
        {
            using (StreamReader wr = new StreamReader(_filePth))
            {
                List<User> users = JsonConvert.DeserializeObject<List<User>>(wr.ReadToEnd());
                return users;
            }
        }

        private void WriteFile(List<User> users)
        {
            using (StreamWriter wr =  new StreamWriter(_filePth))
            {
                string json = JsonConvert.SerializeObject(users, Formatting.Indented);
                wr.WriteLine(json);
            }
        }

        public void AddUser(User user)
        {
            List<User> users = ReaderAllUsers();
            users.Add(user);
            WriteFile(users);
        }

        public void DeleteUser(int id)
        {
            List<User> users = ReaderAllUsers();
            User user = null;

            foreach (var item in users)
            {
                if (item.Id == id)
                {
                    user = item;
                    break;
                }
            }

            if (user != null)
            {
                users.Remove(user);
                WriteFile(users);
                Console.WriteLine("User ugurla silindi");
            }
            else
            {
                Console.WriteLine("Axtardiqiniz User tapilmadi");
            }

        }

        public List<User> GetAllUsers()
        {
            return ReaderAllUsers();
        }

        

        public void UpdateUser(User user, int id)
        {
            List<User> users = ReaderAllUsers();
            User findingUser = null;

            foreach (var item in users)
            {
                if (item.Id == id)
                {
                    findingUser = item;
                    break;
                }
            }

            if (findingUser != null)
            {
                User newUser = new User();
                newUser.Id = findingUser.Id;
                newUser.Name = user.Name;
                newUser.UserName = user.UserName;
                newUser.Email = user.Email;
                newUser.Phone = user.Phone;
                newUser.Website = user.Website;
                users.Remove(findingUser);
                users.Add(newUser);
                WriteFile(users);
                Console.WriteLine("User ugurlar update olundu");

            }
            else
            {
                Console.WriteLine("Axtardiqiniz user tapilmadi");
            }
        }

        public User GetUserById(int id)
        {
            List<User> users = ReaderAllUsers();
            User user = null;

            foreach (var item in users)
            {
                if (item.Id == id)
                {
                    user = item;
                    break;
                }
            }

            if (user != null)
            {
                return user;
            }
            else
            {
                Console.WriteLine("Axtardiqiniz User tapilmadi");
            }

            return user;
        }
    }
}
