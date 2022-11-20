using DAL.Abstract;
using Dapper;
using Domain;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Concrete
{
    public class PostRepository : IPostRepository
    {
        public void CreatPost(Post post)
        {
            string sql = "INSERT INTO Post (Author, Content) VALUES (@Author, @Content)";

            using (var conection = new SqlConnection(DatabaseOptions.DatabaseConnectionString)) 
            {
                conection.Execute(sql, new { Author = post.Author, post.Content });
            }
        }

        public IList<Post> GetPosts()
        {
            List<Post> posts;
            string sql = "SELECT * FROM Post WHERE Created >= DATEADD(day, -1, GETDATE()) ORDER BY Created DESC";

            using (var conection = new SqlConnection(DatabaseOptions.DatabaseConnectionString)) 
            {
                posts = conection.Query<Post>(sql).ToList();
            }

            return posts;
        }
    }
}
