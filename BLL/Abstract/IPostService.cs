
using DataContract;
using System.Collections.Generic;

namespace BLL.Abstract
{
    public interface IPostService
    {
        IList<PostDto> GetPosts();

        void CreatePost(PostDto dto);
    }
}
