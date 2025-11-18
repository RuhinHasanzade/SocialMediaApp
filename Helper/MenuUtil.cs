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
                        GetPostById();
                        break;
                    case 3:
                        AddPost();
                        break;
                    case 4:
                        UpdatePost();
                        break;
                    case 5:
                        DeletePost();
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
                        userService.GetAllUsers().ForEach(user => user.GetUserInfo());
                        break;
                    case 2:
                        Console.WriteLine("Get user by id");
                        GetUserById();
                        break;
                    case 3:
                        Console.WriteLine("Create user");
                        AddUser();
                        break;
                    case 4:
                        Console.WriteLine("UPDATE user");
                        UpdateUser();
                        break;
                    case 5:
                        Console.WriteLine("Delete user");
                        DeleteUser();
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

        private static void AddPost()
        {
            List<User> users = userService.GetAllUsers();
            Console.WriteLine("Create posts");
            Console.Write("ID dagil edin: ");
            string idInp = Console.ReadLine();
            int id = 0;
            try
            {
                id = int.Parse(idInp);
            }
            catch
            {
                Console.WriteLine("Duzgun dagil edin");
                return;
            }

            Console.Write("User Id dagil edin: ");
            string userIdInp = Console.ReadLine();
            int userPostId = 0;
            try
            {
                userPostId = int.Parse(userIdInp);
            }
            catch
            {
                Console.WriteLine("Duzgun dagil edin");
                return;
            }

            bool isUser = false;

            foreach (var item in users)
            {
                if(userPostId == item.Id)
                {
                    isUser = true;
                    break;
                }
            }

            if(isUser)
            {
                Console.Write("Title dagil edin: ");
                string title = Console.ReadLine();
                Console.Write("Body dagil edin: ");
                string body = Console.ReadLine();
                Post crepost = new Post(id, userPostId, title, body);
                postService.AddPost(crepost);
            } else
            {
                Console.WriteLine("Bele bir useriniz yoxdur");
            }

            


        }

        private static void GetPostById()
        {
            Console.Write("Axtartiqiniz post id dagil edin: ");
            string inpId = Console.ReadLine();
            int id = 0;
            try
            {
                id = int.Parse(inpId);
            }
            catch
            {
                Console.WriteLine("Duzgun dagil edin");
                return;
            }
            Post post = postService.GetPostById(id);
            if (post != null)
            {
                post.GetInfoPost();
            }
        }

        private static void UpdatePost()
        {
            Console.WriteLine("UPDATE POST");
            Console.Write("Yeni title dagil edin: ");
            string updatePostTitle = Console.ReadLine();
            Console.Write("Yeni body dagil edin: ");
            string updatePostBody = Console.ReadLine();
            Console.Write("Deyismey istediynz postun id dagil edin");
            string updatePostIdInp = Console.ReadLine();
            int updateid = 0;
            try
            {
                updateid = int.Parse(updatePostIdInp);
            }
            catch
            {
                Console.WriteLine("Duzgun dagil edin");
                return;
            }
            Post updatePost = new Post(updatePostTitle, updatePostBody);
            postService.UpdatePost(updatePost, updateid);
        }

        private static void DeletePost()
        {
            Console.WriteLine("Delete post");
            Console.Write("Silmek istediyinz postun id dagil edin: ");
            string deleteIdInp = Console.ReadLine();
            int deleteid = 0;
            try
            {
                deleteid = int.Parse(deleteIdInp);
            }
            catch
            {
                Console.WriteLine("Duzgun dagil edin");
                return;
            }
            postService.DeletePost(deleteid);
        }

        ///////////USER MENU////////////
        
        private static void GetUserById()
        {
            Console.Write("Axtartiqiniz user id dagil edin: ");
            string inpId = Console.ReadLine();
            int id = 0;
            try
            {
                id = int.Parse(inpId);
            }
            catch
            {
                Console.WriteLine("Duzgun dagil edin");
                return;
            }
            User user = userService.GetUserById(id);
            if (user != null)
            {
                user.GetUserInfo();
            }
        }

        private static void AddUser()
        {

            Console.WriteLine("Create User");
            Console.Write("ID dagil edin: ");
            string idInp = Console.ReadLine();
            int id = 0;
            try
            {
                id = int.Parse(idInp);
            }
            catch
            {
                Console.WriteLine("Duzgun dagil edin");
                return;
            }
            Console.Write("Name dagil edin: ");
            string name = Console.ReadLine();
            Console.Write("Username dagil edin: ");
            string username = Console.ReadLine();
            Console.Write("Phone number dagil edin: ");
            string phoneNum = Console.ReadLine();
            Console.Write("Email dagil edin: ");
            string email = Console.ReadLine();
            Console.Write("Website dagil edin: ");
            string website = Console.ReadLine();

            User user = new User(id,name,username,email,phoneNum,website);
            userService.AddUser(user);
        }

        private static void UpdateUser()
        {
            Console.WriteLine("UPDATE USER");
            Console.Write("Yeni name dagil edin: ");
            string name = Console.ReadLine();
            Console.Write("Yeni username dagil edin: ");
            string username = Console.ReadLine();
            Console.Write("Yeni email dagil edin: ");
            string email = Console.ReadLine();
            Console.Write("Yeni phone dagil edin: ");
            string phone = Console.ReadLine();
            Console.Write("Yeni website dagil edin: ");
            string website = Console.ReadLine();


            Console.Write("Deyismey istediynz userin id dagil edin");
            string updateUserIdInp = Console.ReadLine();
            int updateid = 0;
            ;
            try
            {
                updateid = int.Parse(updateUserIdInp);
            }
            catch
            {
                Console.WriteLine("Duzgun dagil edin");
                return;
            }
            User user = new User(name,username,email,phone,website);

            userService.UpdateUser(user , updateid);
        }

        private static void DeleteUser()
        {
            Console.WriteLine("Delete User");
            Console.Write("Silmek istediyinz userin id dagil edin: ");
            string deleteIdInp = Console.ReadLine();
            int deleteid = 0;
            try
            {
                deleteid = int.Parse(deleteIdInp);
            }
            catch
            {
                Console.WriteLine("Duzgun dagil edin");
                return;
            }
            userService.DeleteUser(deleteid);
        }
    }
}
