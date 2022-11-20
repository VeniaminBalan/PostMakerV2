using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace DAL.Abstract
{
    public interface IUserRepository
    {
        void Signup(User user);
        User Login(User user);
        bool IsEmailUsed(string Email);
        bool IsNameUsed(string user);
    }
}
