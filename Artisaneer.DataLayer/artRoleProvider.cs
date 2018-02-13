using Artisaneer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Artisaneer.DataLayer
{
    public class artRoleProvider : RoleProvider
    {
        private readonly MembershipRepository _membrepository;
        private readonly RoleRepository _rolerepository;
        public artRoleProvider()
         {
             this._membrepository = new MembershipRepository();
             this._rolerepository = new RoleRepository();
         }

         public override bool IsUserInRole(string userId, string roleName)
         {
             Person user = _membrepository.GetUser(userId);
             Role role = _rolerepository.GetRole(roleName);

             if (!_rolerepository.UserExists(user))
                 return false;
             if (!_rolerepository.RoleExists(role))
                 return false;

             return user.Role.RoleName == role.RoleName;
         }

         public override string[] GetRolesForUser(string userRole)
         {
             Role role = this._rolerepository.GetRoleForUser(userRole);
             if (!this._rolerepository.RoleExists(role))
                 return new string[] { string.Empty };

             return new string[] { role.RoleName };
         }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
