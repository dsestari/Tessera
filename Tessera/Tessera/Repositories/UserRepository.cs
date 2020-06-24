using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tessera.Models;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using Tessera.Utilities;
using System.Web.Security;

namespace Tessera.Repositories
{
    public class UserRepository
    {
        public void BlockUser(string email)
        {
            using (Context db = new Context())
            {
                var bList = db.BlockLists.Where(l => l.Username == email
                                                && l.DateInsert.Day == System.DateTime.Now.Day
                                                && l.DateInsert.Month == System.DateTime.Now.Month
                                                && l.DateInsert.Year == System.DateTime.Now.Year).ToList();

                if (bList != null && bList.Count() >= 3)
                {
                    User user = new User();

                    user = db.Users.Include(s => s.UserStatus).SingleOrDefault(u => u.Email == email && u.UserStatus.Id != 3);

                    if (user != null)
                    {
                        user.UserStatusId = 3;

                        db.Entry(user).State = System.Data.Entity.EntityState.Modified;

                        db.SaveChanges();

                        BlockListRepository.DeleteBlockList(email);
                    }
                }
            };
        }

        public bool CheckEmail(string email)
        {
            using (Context db = new Context())
            {
                var user = db.Users.SingleOrDefault(u => u.Email == email);

                if (user != null)
                {
                    Helper.SendMailRememberAccess(user.Email, Helper.Decode(user.Password));
                    return true;
                }
                else
                    return false;
            };
        }

        public User GetUserByName(string name)
        {
            using (Context db = new Context())
            {
                return db.Users.SingleOrDefault(u => u.Name == name);
            }
        }

        public void PersistUser(User user)
        {
            using (Context db = new Context())
            {
                if (user.Id == 0)
                {
                    db.Entry(user).State = System.Data.Entity.EntityState.Added;

                    Helper.SendMailFirstAccess(user.Email, Helper.Decode(user.Password));
                }
                else
                {
                    var userInDb = db.Users.Single(u => u.Id == user.Id);

                    userInDb.Name = user.Name;
                    userInDb.GroupId = user.GroupId;
                    userInDb.UserStatusId = user.UserStatusId;
                    userInDb.Email = user.Email;
                }

                db.SaveChanges();
            }
        }

        public User GetUserById(int id)
        {
            using (Context db = new Context())
            {
                return db.Users.SingleOrDefault(u => u.Id == id);
            }
        }

        public List<AuthenticationReturn> Login(string email, string password)
        {
            using (Context db = new Context())
            {
                var authenticationReturn = new List<AuthenticationReturn>();

                var encodePassword = Helper.Encode(password);

                var user = db.Users.Include(s => s.UserStatus).SingleOrDefault(u => u.Email == email && u.Password == encodePassword);

                if (user != null)
                {
                    if (user.UserStatusId == 2 || user.UserStatusId == 3)
                    {
                        authenticationReturn.Add(new AuthenticationReturn { authReturn = false, message = "Your account is Inactived or Blocked" });

                        return authenticationReturn;
                    }
                    else if (user.FirstAccess == true && (user.RegistrationDate.Date < System.DateTime.Now.Date))
                    {
                        authenticationReturn.Add(new AuthenticationReturn { authReturn = false, message = "Your password is expired" });

                        return authenticationReturn;
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(user.Name, true);

                        authenticationReturn.Add(new AuthenticationReturn { authReturn = true, message = user.Id.ToString() });

                        return authenticationReturn;
                    }
                }
                else
                {
                    var userLog = new UserLog();
                    userLog.Username = email;
                    userLog.DataLog = System.DateTime.Now;
                    userLog.Description = "Incorrect email or password";
                    UserLogRepository.InsertUserLog(userLog);

                    var bList = new BlockList();
                    bList.Username = email;
                    bList.DateInsert = System.DateTime.Now;
                    BlockListRepository.InsertBlockList(bList);

                    var userRepository = new UserRepository();
                    userRepository.BlockUser(email);

                    authenticationReturn.Add(new AuthenticationReturn { authReturn = false, message = userLog.Description });

                    return authenticationReturn;
                }

            }
        }

        public bool ChangePassword(string email, string currentPassword, string newPassword)
        {
            var passwordEncode = Helper.Encode(currentPassword);

            using (Context db = new Context())
            {
                var user = db.Users.SingleOrDefault(u => u.Email == email && u.Password == passwordEncode);

                if (user != null)
                {
                    var modelUser = new User();

                    modelUser = user;
                    modelUser.Password = Helper.Encode(newPassword);
                    modelUser.FirstAccess = false;

                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }

        public List<User> GetUsersByGroup(int groupId)
        {
            using (Context db = new Context())
            {
                return db.Users.Where(u => u.GroupId == groupId).ToList();
            }
        }
    }
}