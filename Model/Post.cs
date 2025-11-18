using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSocialApp.Model
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set;}
        public string Title {  get; set; }

        public string Body { get; set; }

        public Post()
        {

        }

        public Post(int id, int userId, string title, string body)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Body = body;
        }

        public Post(string title, string body)
        {
            Title = title; 
            Body = body;
        }

        public void GetInfoPost()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"ID      : {Id}");
            Console.WriteLine($"User ID : {UserId}");
            Console.WriteLine($"Title   : {Title}");
            Console.WriteLine($"Body    : {Body}");
            Console.WriteLine("-------------------------------------------------\n");
        }

        
    }
}
