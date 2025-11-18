using MiniSocialApp.Helper;
using MiniSocialApp.Model;
using MiniSocialApp.Service;
using MiniSocialApp.Service.Impl;

namespace MiniSocialApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());

            string postJson = "C:\\Users\\ASUS\\source\\repos\\MiniSocialApp\\MiniSocialApp\\Data\\posts.json";
            string userJson = "C:\\Users\\ASUS\\source\\repos\\MiniSocialApp\\MiniSocialApp\\Data\\users.json";


            //Console.WriteLine(postJson);

            IPostService postService = new PostServiceImpl(postJson);

            //List<Post> posts = postService.GetAllPosts();

            //foreach (var item in posts)
            //{
            //    item.GetInfoPost();
            //}

            //Post post = new Post();
            //post.Id = 52;
            //post.UserId = 5;
            //post.Title = "New Roman";
            //post.Body = "dada dnfjfjsfkla";

            //postService.AddPost(post);

            //Post udpatePost = new Post("Test yenilenmis post", "Bu post yenilenib update olunub");
            //postService.UpdatePost(udpatePost, 2);

            IUserService userService = new UserServiceImpl(userJson);

            //List<User> users = userService.GetAllUsers();

            //foreach (var item in users)
            //{
            //    item.GetUserInfo();
            //}

            //User newUser = new User();
            //newUser.Id = 4;
            //newUser.Name = "Ruhin Hasanzada";
            //newUser.UserName = "5.7";
            //newUser.Email = "ruhinhasanzade@gmail.com";
            //newUser.Phone = "050-536-57-1";
            //newUser.Website = "ruhin.dev";

            //userService.AddUser(newUser);

            //userService.DeleteUser(2);

            //User finUser = userService.GetUserById(2);
            //finUser.GetUserInfo();
            //Post post = postService.GetPostById(12);
            //post.GetInfoPost();

            //User updateUser = new User("Ayxan Besirov", "Ayka", "ayka@mail.ru","050-43-33-3-3","ayka.info");

            //userService.UpdateUser(updateUser, 3);

            MenuUtil.StartMenu();

        }
    }
}
