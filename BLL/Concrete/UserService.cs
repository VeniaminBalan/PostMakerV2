using BLL.Abstract;
using DAL.Abstract;
using DataContract;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public void Signup(UserDto dto)
        {
            var user = new User()
            {
                Email = dto.Email,
                Password = dto.Password,
                Name = dto.Name,
                Id = dto.Id
            };

            _userRepository.Signup(user);
        }

        public User Login(UserDto dto)
        {
            var user = new User()
            {
                Email = dto.Email,
                Password = dto.Password,
                Name = dto.Name,
                Id = dto.Id
            };

            return _userRepository.Login(user);
        }

        public bool IsEmailUsed(UserDto user)
        {

            return _userRepository.IsEmailUsed(user.Email);
        }

        public bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }


        public bool IsNameUsed(UserDto user)
        {
            return _userRepository.IsNameUsed(user.Name);
        }

        public IList<PostDto> GetUserPosts(string Name)
        {
            var posts = _userRepository.GetUserPosts(Name);

            var dtos = posts.Select(x => new PostDto()
            {
                Author = x.Author,
                Content = x.Content,
                Created = x.Created,
                Id = x.Id
            }).ToList();

            return dtos;
        }
    }
}
