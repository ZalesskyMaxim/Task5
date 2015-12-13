using Model.Users.UsersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task5MVCProject.Global.Auth
{
    public interface IUserProvider
    {
        User User { get; set; }
    }
}