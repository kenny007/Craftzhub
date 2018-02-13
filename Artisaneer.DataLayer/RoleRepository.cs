using Artisaneer.DataLayer.Repository;
using Artisaneer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Artisaneer.DataLayer
{
    public class RoleRepository : RepositoryBase<ArtisanHubEntities, Role>
    {
        #region Variables
        private const string MissingUser = "User does not exist";
        private const string TooManyUser = "User already exists";
        private const string MissingRole = "Role does not exist";
        private const string TooManyRole = "Role already exists";
        private const string AssignedRole = "Cannot delete a role with assigned users";

        #endregion Variables
        #region Properties

        public int NumberOfUsers
        {
            get
            {
                return _entities.People.Count();
            }
        }

        public int NumberOfRoles
        {
            get
            {
                return _entities.Roles.Count();
            }
        }

        #endregion

        #region Query Methods

        public IQueryable<Role> GetAllRoles()
        {
            return from role in _entities.Roles
                   orderby role.RoleName
                   select role;
        }

        public Role GetRole(int id)
        {
            return _entities.Roles.SingleOrDefault(role => role.RoleId == id);
        }

        public Role GetRole(string name)
        {
            return _entities.Roles.SingleOrDefault(role => role.RoleName == name);
        }

        public Role GetRoleForUser(string userId)
        {
            return GetRoleForUser(GetUser(userId));
        }

        public Role GetRoleForUser(Person user)
        {
            if (!UserExists(user))
                throw new ArgumentException(MissingUser);
            return user.Role;
        }

        #endregion

        #region Insert/Delete


        public Person GetUser(string userName)
        {
            return _entities.People.SingleOrDefault(user => user.UserName == userName);
        }

        private void AddUser(Person user)
        {
            if (UserExists(user))
                throw new ArgumentException(TooManyUser);

            _entities.People.Add(user);
        }
        
        public void CreateUser(string firstName,string userName, string eMail, string lastName, string staTe, 
              string localGovt, string numBer, string addRess,string passWord, string confirmPassword, string roleName, int skillid, RegisterModel registerM)
        {
            int regno = 0;
            Role role = GetRole(roleName);
            OfficeOnline.DataBlock.TableSerialNo ts = new OfficeOnline.DataBlock.TableSerialNo();
            if (string.IsNullOrEmpty(userName.Trim())) throw new ArgumentException("The user name provided is invalid. Please check the value and try again.");
            if (string.IsNullOrEmpty(eMail.Trim())) throw new ArgumentException("The user name provided is invalid. Please check the value and try again.");
            if (string.IsNullOrEmpty(passWord.Trim())) throw new ArgumentException("The password provided is invalid. Please enter a valid password value.");
            if (string.IsNullOrEmpty(addRess.Trim())) throw new ArgumentException("The address provided is invalid. Please enter a valid password value.");
            if (string.IsNullOrEmpty(numBer.Trim())) throw new ArgumentException("The number provided is invalid. Please enter a valid password value.");
            if (string.IsNullOrEmpty(firstName.Trim())) throw new ArgumentException("The  Firstname provided is invalid. Please check the value and try again.");
            if (string.IsNullOrEmpty(lastName.Trim())) throw new ArgumentException("The Lastname provided is invalid. Please check the value and try again.");
           
            if (!RoleExists(role)) throw new ArgumentException("The role selected for this user does not exist! Contact an administrator!");
            if (this._entities.People.Any(user => user.UserName == userName))
                throw new ArgumentException("The username already exists. Please choose another username");

            Person newUser = new Person()
            {
                LastName = lastName,
                FirstName = firstName,
                Password = FormsAuthentication.HashPasswordForStoringInConfigFile(passWord.Trim(), "md5"),
                ConfirmPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(confirmPassword.Trim(), "md5"),
                State = staTe,
                LGA = localGovt,
                PhoneNumber = numBer,
                UserName = userName,
                Email = eMail,
                Address1 = addRess,
                RoleId = role.RoleId,
                SkillId = skillid,
                RegDate = DateTime.Now
            };

            try
            {
                AddUser(newUser);
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }
            catch (Exception e)
            {
                throw new ArgumentException("The authentication provider returned an error. Please verify your entry and try again. " +
                    "If the problem persists, please contact your system administrator.");
            }

            // Immediately persist the user data
            Save();
        }

        public void DeleteUser(Person user)
        {
            if (!UserExists(user))
                throw new ArgumentException(MissingUser);

            _entities.People.Remove(user);
        }

        public void DeleteUser(string userName)
        {
            DeleteUser(GetUser(userName));
        }

        public void AddRole(Role role)
        {
            if (RoleExists(role))
                throw new ArgumentException(TooManyRole);

            _entities.Roles.Add(role);
        }

        public void AddRole(string roleName)
        {
            Role role = new Role()
            {
                RoleName = roleName
            };

            AddRole(role);
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

        public void DeleteRole(Role role)
        {
            if (!RoleExists(role))
                throw new ArgumentException(MissingRole);

            if (GetUsersForRole(role).Count() > 0)
                throw new ArgumentException(AssignedRole);

            _entities.Roles.Remove(role);
        }

        public void DeleteRole(string roleName)
        {
            DeleteRole(GetRole(roleName));
        }

        #endregion

        #region Persistence

        public void Save()
        {
            _entities.SaveChanges();
        }

        #endregion

        #region Helper Methods

        public bool UserExists(Person user)
        {
            if (user == null)
                return false;

            return (_entities.People.SingleOrDefault(u => u.PersonId == user.PersonId) != null);
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
