using MiniSocialApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSocialApp.Service
{
    public interface IPostService
    {
        List<Post> GetAllPosts();
        Post GetPostById(int id);

        void AddPost(Post post);

        void UpdatePost(Post post , int id);

        void DeletePost(int id);
    }
}
