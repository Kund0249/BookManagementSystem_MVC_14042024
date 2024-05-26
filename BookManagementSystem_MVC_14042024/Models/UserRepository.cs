using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementSystem_MVC_14042024.Models
{
    public class UserEntity
    {
        public string UserName { get; set; }

        public string Password { get; set; }
        public string[] Roles { get; set; }
    }
    public class UserRepository
    {
        public static List<UserEntity> userEntities;
        public UserRepository()
        {
            userEntities = new List<UserEntity>()
            {
                new UserEntity(){UserName="abhishek",Password="123456",Roles=new string[]{"Admin","HR" } },
                new UserEntity(){UserName="vishal",Password="123456",Roles=new string[]{"user", } },
                new UserEntity(){UserName="namita",Password="123456",Roles=new string[]{"Manager" } }
            };
        }

        public bool IsValidUser(string username,string password)
        {
            var user = userEntities.SingleOrDefault(x => x.UserName == username && x.Password == password);

            if (user != null)
                return true;

            return false;
        }
        public string[] GetUserRoles(string username)
        {
          var user =  userEntities.SingleOrDefault(x => x.UserName == username);

            if (user != null)
                return user.Roles;

            return null;
        }
    }
}