using MiniSocialApp.Model;
using Newtonsoft.Json;

namespace MiniSocialApp.Service.Impl
{
    public class PostServiceImpl : IPostService
    {
        private readonly string _filePth;

        public PostServiceImpl(string filePth)
        {
            _filePth = filePth;
        }

        private List<Post> ReadAllPost()
        {
            using (StreamReader wr = new StreamReader(_filePth))
            {
                List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(wr.ReadToEnd());
                return posts;
            }
        }

        private void WritePost(List<Post> posts)
        {
            using(StreamWriter wr = new StreamWriter(_filePth))
            {
                string json = JsonConvert.SerializeObject(posts , Formatting.Indented);
                wr.Write(json);
            }
        }

        public void AddPost(Post post)
        {
            if (post.Id < 1 || post.UserId < 1)
            {
                Console.WriteLine("Id 1 den kicik ola bilmez");
                return;
            }

            List<Post> posts = ReadAllPost();
            bool isPost = false;
            foreach (var item in posts)
            {
                if(post.Id == item.Id)
                {
                    isPost = true;
                    break;
                }
            }

            if(isPost)
            {
                Console.WriteLine("Eyni id li post yaratmaq olazm");
                return;

            }

            if (string.IsNullOrWhiteSpace(post.Title) || string.IsNullOrWhiteSpace(post.Body))
            {
                Console.WriteLine("Saheleri tam doldurun");
            }


            posts.Add(post);
            WritePost(posts);
            Console.WriteLine("Post ugurla elave olundu");
        }

        public void DeletePost(int id)
        {
            List<Post> posts = ReadAllPost();
            Post findingPost = null;

            foreach (Post post in posts)
            {
                if (post.Id == id)
                {

                    findingPost = post;
                    break;
                }
            }

            if (findingPost == null)
            {
                Console.WriteLine("Axtardiqiniz id tapilmadi");
            }
            else
            {
                posts.Remove(findingPost);

                WritePost(posts);

                Console.WriteLine($"ID {id} uğurla silindi.");
            }
        }

        public List<Post> GetAllPosts()
        {
            return ReadAllPost();
        }

        public Post GetPostById(int id)
        {
            List<Post> posts = ReadAllPost();

            Post findingPost = null; 

            foreach (Post post in posts)
            {
                if(post.Id == id)
                {
                    
                    findingPost = post; 
                    break;
                }
            }

            if(findingPost == null)
            {
                Console.WriteLine("Axtardiqiniz id tapilmadi");
            }

            return findingPost;
        }

        public void UpdatePost(Post post , int id)
        {
            List<Post> posts = ReadAllPost();
            Post findingPost = null;

            foreach (var item in posts)
            {
                if (item.Id == id)
                {
                    findingPost = item;
                    break;
                }   
            }

            if (findingPost == null)
            {
                Console.WriteLine("Axtardiqiniz id tapilmadi");
            } else
            {
                Post nPost = new Post();
                nPost.Id = findingPost.Id;
                nPost.UserId = findingPost.UserId;
                nPost.Title = post.Title;
                nPost.Body = post.Body;
                posts.Remove(findingPost);
                posts.Add(nPost);
                WritePost(posts);
                Console.WriteLine("Post ugurla yenilendi");
            }
        }
    }
}
