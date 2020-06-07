using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Handler
{
    public class UserHandler
    {
        public static void insertNewUser(string name, string email, string password, string gender)
        {
            UserRepository.insert(UserFactory.createNewUser(name, email, password, gender));
        }

        public static void updateCurrentUser(int id, string name, string email, string gender)
        {
            UserRepository.update(id, name, email, gender);
        }

        public static void changeUserStatus(string email, int roleId, string status)
        {
            UserRepository.update(email, roleId, status);
        }

        public static List<vUser> getUserData()
        {
            return UserRepository.read();
        }

        public static bool IsUserAnAdmin(string email)
        {
            if (UserRepository.findUser(email).RoleID == 1) return true;
            return false;
        }

        public static bool isUserCredentialCorrent(string email, string password)
        {
            return (UserRepository.findUser(email, password) != null) ? true : false;
        }

        public static bool isUserBlocked(string email)
        {
            if (UserRepository.findUser(email).UStatus != "active") return true;
            return false;
        }

        public static string getOldPassword(string email)
        {
            return UserRepository.findUser(email).UPassword;
        }

        public static void changePassword(string email, string password)
        {
            UserRepository.updatePassword(email, password);
        }

        public static User findUser(string email)
        {
            return UserRepository.findUser(email);
        }

        public static bool findExistUser(string email)
        {
            if (UserRepository.findUser(email) != null) return true;
            return false;
        }
    }
}