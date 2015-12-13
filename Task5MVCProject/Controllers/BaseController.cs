﻿using Model.Users.UsersModel;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5MVCProject.Global.Auth;
using Task5MVCProject.Mappers;

namespace Task5MVCProject.Controllers
{
    public abstract class BaseController : Controller
    {
        [Inject]
        public IRepository Repository { get; set; }

        [Inject]
        public IMapper ModelMapper { get; set; }

        [Inject]
        public IAuthentication Auth { get; set; }

        public User CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }
    }
}
