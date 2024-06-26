﻿using BLL.Abstract;
using BLL.Concrete;
using DAL.Concrete;
using Domain;
using DataContract;
using Microsoft.AspNetCore.Mvc;
using PostMakerV2.Models;
using System.Net;

namespace PostMakerV2.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public static Cookie cookie = null;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = new UserDto()
            {
                Email = model.Email,
                Password = model.Password,
            };
            User logedUser = _userService.Login(user);

            if (logedUser != null) 
            {
                cookie = new Cookie(logedUser.Name, logedUser.Email);
                return RedirectToAction("Index", "Home");
            }
               
            else return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {

            cookie = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignupViewModel model)
        {
            if (!ModelState.IsValid) return View();

            if (model.Password != model.PasswordConfirm)
            {
                ModelState.AddModelError("Password", "Password did not match");
            }
            if (_userService.IsEmailUsed(new UserDto()
            {
                Email = model.Email
            }))
                ModelState.AddModelError("Email", "This Email is already used");
            if (_userService.IsNameUsed(new UserDto()
            {
                Name = model.Name

            })) ModelState.AddModelError("Name", "This Name is already used");

            if (!_userService.IsValidEmail(model.Email))
                ModelState.AddModelError("Email", "Please enter valid email");

            if (ModelState.IsValid)
            {
                var user = new UserDto()
                {
                    Email = model.Email,
                    Password = model.Password,
                    PasswordConfirm = model.PasswordConfirm,
                    Name = model.Name
                };

                _userService.Signup(user);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        
        public IActionResult UserMenu()
        {

            var dtos = _userService.GetUserPosts(UserController.cookie.Name);
            var posts = dtos.Select(x => new PostViewModel()
            {
                Author = x.Author,
                Content = x.Content,
                Created = x.Created.ToString()
            }).ToList();

            return View(posts);
        }

        //public IActionResult Component()
        //{
        //    var dtos = _postService.GetPosts();
        //    var posts = dtos.Select(x => new PostViewModel()
        //    {
        //        Author = x.Author,
        //        Content = x.Content,
        //        Created = x.Created.ToString()
        //    }).ToList();

        //    posts = posts.FindAll(x => x.Author == UserController.cookie.Name);


        //    return View(posts);
        //}

    }
}
