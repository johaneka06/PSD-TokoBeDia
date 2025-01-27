﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Factory
{
    public class UserFactory
    {
        public static User createNewUser(String name, String email, String password, String gender)
        {
            User newUser = new User()
            {
                UEmail = email,
                UName = name,
                UPassword = password,
                UGender = gender,
                UStatus = "active",
                RoleID = 100
            };
            return newUser;
        }

    }
}