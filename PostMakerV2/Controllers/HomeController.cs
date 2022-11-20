using BLL.Abstract;
using DataContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostMakerV2.Models;
using System.Diagnostics;

namespace PostMakerV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            var dtos = _postService.GetPosts();
            var posts = dtos.Select(x => new PostViewModel()
            {
                Author = x.Author,
                Content = x.Content,
                Created = x.Created.ToString()
            }).ToList();

            return View(posts);
        }


        [HttpGet]
        public IActionResult CreatePost()
        {
            if (UserController.cookie == null)
                return RedirectToAction("Login", "User");
            return View();
        }


        [HttpPost]
        public IActionResult CreatePost(CreatePostViewModel model)
        {

            if (model.Content != null)
            {
                var post = new PostDto()
                {
                    Author = UserController.cookie.Name,
                    Content = model.Content
                };

                _postService.CreatePost(post);
                return RedirectToAction("Index");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}