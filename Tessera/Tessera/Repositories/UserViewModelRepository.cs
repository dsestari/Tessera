using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tessera.ViewModels;
using System.Data.Entity;
using Tessera.Models;

namespace Tessera.Repositories
{
    public class UserViewModelRepository
    {
        public UserFormViewModel GetNewUserGroupAndStatus()
        {
            using (Context db = new Context())
            {
                var viewModel = new UserFormViewModel
                {
                    User = new User(),
                    Groups = db.Groups.ToList(),
                    UserStatus = db.UsersStatus.Where(u => u.Id != 3).ToList()
                };

                return viewModel;
            }
        }

        public UserFormViewModel GetUserGroupAndStatus(User user)
        {
            using (Context db = new Context())
            {
                var viewModel = new UserFormViewModel
                {
                    User = user,
                    Groups = db.Groups.ToList(),
                    UserStatus = db.UsersStatus.Where(u => u.Id != 3).ToList()
                };

                return viewModel;
            }
        }

        public UserFormViewModel GetUserGroupAndStatusForEdit(User user)
        {
            using (Context db = new Context())
            {
                var viewModel = new UserFormViewModel
              {
                  User = user,
                  Groups = db.Groups.ToList(),
                  UserStatus = user.UserStatusId == 3 ? db.UsersStatus.ToList() : db.UsersStatus.Where(u => u.Id != 3).ToList()
              };

              return viewModel;
            }
        }
    }
}