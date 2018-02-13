using Artisaneer.DataLayer.Repository;
using Artisaneer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artisaneer.DataLayer
{
    public class MembershipRepository :
     RepositoryBase<ArtisanHubEntities, Role>
    {
        #region variables
        private const string MissingUser = "User does not exist";
        private const string TooManyUser = "User already exists";
        private const string MissingRole = "Role does not exist";
        private const string TooManyRole = "Role already exists";
        private const string AssignedRole = "Cannot delete a role with assigned users";
        #endregion

        public IQueryable<Person> GetAllUsers()
        {
            return from user in _entities.People
                   orderby user.PersonId
                   select user;
        }

        public Person GetUser(string userName)
        {
            return _entities.People.SingleOrDefault(user => user.UserName == userName);
        }

        public IQueryable<Person> GetUsersForRole(string roleName)
        {
            return GetUsersForRole(GetRole(roleName));
        }

        public IQueryable<Person> GetUsersForRole(int id)
        {
            return GetUsersForRole(GetRole(id));
        }

        public IQueryable<Person> GetUsersForRole(Role role)
        {
            if (!RoleExists(role))
                throw new ArgumentException(MissingRole);

            return from user in _entities.People
                   where user.RoleId == role.RoleId
                   orderby user.LastName
                   select user;
        }

        public Role GetRole(int id)
        {
            return _entities.Roles.SingleOrDefault(role => role.RoleId == id);
        }

        public Role GetRole(string name)
        {
            return _entities.Roles.SingleOrDefault(role => role.RoleName == name);
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
        #region Helper Methods

        public bool UserExists(Person user)
        {
            if (user == null)
                return false;

            return (_entities.People.SingleOrDefault(u => u.RoleId == user.RoleId || u.PersonId == user.PersonId) != null);
        }

        public bool RoleExists(Role role)
        {
            if (role == null)
                return false;

            return (_entities.Roles.SingleOrDefault(r => r.RoleId == role.RoleId || r.RoleName == role.RoleName) != null);
        }

        #endregion
    }
}
