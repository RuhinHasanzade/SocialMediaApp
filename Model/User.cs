using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSocialApp.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }

        public User() { }

        public User(string name , string username , string email , string phone, string website)
        {
            Name = name;
            UserName = username;
            Email = email;
            Phone = phone;
            Website = website;
        }


        public void GetUserInfo()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Username: {UserName}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone: {Phone}");
            Console.WriteLine($"Website: {Website}");
            Console.WriteLine("-------------------------");
        }

    }
}
