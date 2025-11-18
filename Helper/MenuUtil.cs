using MiniSocialApp.Model;
using MiniSocialApp.Service;
using MiniSocialApp.Service.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSocialApp.Helper
{
    internal class MenuUtil
    {
        private static string postJson = "C:\\Users\\ASUS\\source\\repos\\MiniSocialApp\\MiniSocialApp\\Data\\posts.json";
        private static string userJson = "C:\\Users\\ASUS\\source\\repos\\MiniSocialApp\\MiniSocialApp\\Data\\users.json";

        private static IUserService userService = new UserServiceImpl(userJson);
        private static IPostService postService = new PostServiceImpl(postJson);

        public static void StartMenu()
        {
            while (true)
            {
                Console.WriteLine("1. USER");
                Console.WriteLine("2. POST");
                Console.WriteLine("0. EXIT");
                Console.Write("Menudan secim edin: ");
                int choice = 0;
                string inp = Console.ReadLine();
                try
                {
                     choice = int.Parse(inp);
                }catch
                {
                    Console.WriteLine("Zehmet olmasa duzgun dagil edin");
                    continue;
                }
                

                switch (choice)
                {
                    case 1:
                        UserMenu();
                        break;

                    case 2:
                        PostMenu();
                        break;
                    case 0:
                        Console.WriteLine("EXIT....");
                        return;

                    default:
                        Console.WriteLine("Yalnis secim");
                        break;

                }
            }
        }


        private static void PostMenu()
        {
            while(true)
            {
                Console.WriteLine("1. SHOW ALL POSTS");
                Console.WriteLine("2. GET POST BY ID");
                Console.WriteLine("3. CREATE POST");
                Console.WriteLine("4. UDDATE POST");
                Console.WriteLine("5. DELETE POST");
                Console.WriteLine("0. EXIT___");
                Console.Write("Secim: ");
                int choice = 0;
                string inp = Console.ReadLine();
                try
                {
                    choice = int.Parse(inp);
                }
                catch
                {
                    Console.WriteLine("Zehmet olmasa duzgun dagil edin");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        postService.GetAllPosts().ForEach(post => post.GetInfoPost());
                        break;
                    case 2:
                        Console.Write("Axtartiqiniz post id dagil edin: ");
                        string inpId = Console.ReadLine();
                        int id = 0;
                        try
                        {
                            id = int.Parse(inpId);
                        }catch
                        {
                            Console.WriteLine("Duzgun dagil edin");
                            continue;
                        }
                        Post post = postService.GetPostById(id);
                        if(post!= null)
                        {
                            post.GetInfoPost();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Create posts");
                        Console.Write("ID dagil edin: ");
                        
                        break;
                    case 4:
                        Console.WriteLine("UPDATE POST");
                        break;
                    case 5:
                        Console.WriteLine("Delete post");
                        break;
                    case 0:
                        Console.WriteLine("Exit--");
                        return;

                    default:
                        Console.WriteLine("Yalnis secim");
                        break;

                }
            }
        }


        private static void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("1. SHOW ALL USERS");
                Console.WriteLine("2. GET USER BY ID");
                Console.WriteLine("3. CREATE USER");
                Console.WriteLine("4. UDDATE USER");
                Console.WriteLine("5. DELETE USER");
                Console.WriteLine("0. EXIT___");
                Console.Write("Secim: ");
                int choice = 0;
                string inp = Console.ReadLine();
                try
                {
                    choice = int.Parse(inp);
                }
                catch
                {
                    Console.WriteLine("Zehmet olmasa duzgun dagil edin");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Show All User");
                        break;
                    case 2:
                        Console.WriteLine("Get user by id");
                        break;
                    case 3:
                        Console.WriteLine("Create user");
                        break;
                    case 4:
                        Console.WriteLine("UPDATE user");
                        break;
                    case 5:
                        Console.WriteLine("Delete user");
                        break;
                    case 0:
                        Console.WriteLine("Exit--");
                        return;

                    default:
                        Console.WriteLine("Yalnis secim");
                        break;

                }
            }

        }
    }
}
