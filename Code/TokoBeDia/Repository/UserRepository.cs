using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class UserRepository
    {
        private static TokoBeDiaDBEntities db = DBSingleton.GetInstance();

        public static void insert(User newUser)
        {
            db.Users.Add(newUser);
            db.SaveChanges();
        }

        public static List<vUser> read()
        {
            return db.vUsers.ToList();
        }

        public static void update(int id, string name, string email, string gender)
        {
            User currentUser = db.Users.Where(x => x.UserID == id).FirstOrDefault();
            currentUser.UName = name;
            currentUser.UEmail = email;
            currentUser.UGender = gender;
            db.SaveChanges();
        }

        public static void update(string email, int roleId, string status)
        {
            User u = db.Users.Where(x => x.UEmail == email).FirstOrDefault();
            u.RoleID = roleId;
            u.UStatus = status;
            db.SaveChanges();
        }

        public static User findUser(String email)
        {
            return db.Users.Where(usr => usr.UEmail == email).FirstOrDefault();
        }

        public static User findUser(string email, string password)
        {
            return db.Users.Where(u => u.UEmail == email && u.UPassword == password).FirstOrDefault();
        }

        public static void updatePassword(string email, string password)
        {
            User currentUser = db.Users.Where(x => x.UEmail == email).FirstOrDefault();
            currentUser.UPassword = password;
            db.SaveChanges();
        }
    }
}