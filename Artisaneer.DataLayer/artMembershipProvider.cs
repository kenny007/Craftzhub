using Artisaneer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Artisaneer.DataLayer
{
    public class artMembershipProvider : MembershipProvider
    {
        private readonly MembershipRepository _membrepository;
        private readonly RoleRepository _rolerepository;
        public artMembershipProvider()
         {
             this._membrepository = new MembershipRepository();
             this._rolerepository = new RoleRepository();
         }

        public override int MinRequiredPasswordLength
        {
            get { return 6; }
        }

         public override bool ValidateUser(string username, string password)
         {
             if (string.IsNullOrEmpty(username.Trim()) || string.IsNullOrEmpty(password.Trim()))
                 return false;

             string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Trim(), "md5");

             return this._membrepository.GetAllUsers().Any(user => (user.UserName == username.Trim()) && (user.Password == hash));

         }
       
         public void CreateUser(string firstname, string username, string email, string lastname,string state,string localgovt,
             string number, string address, string password, string confirmpassword, string rolename, int skillid, RegisterModel registerM)
         {
             this._rolerepository.CreateUser(firstname, username, email, lastname, state, localgovt, number, address, 
                 password, confirmpassword, rolename,skillid, registerM);
         }

         public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
         {
             throw new NotImplementedException();
         }

         public override bool ChangePassword(string username, string oldPassword, string newPassword)
         {
             if (!ValidateUser(username, oldPassword) || string.IsNullOrEmpty(newPassword.Trim()))
                 return false;

             Person user = _membrepository.GetUser(username);
             string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(newPassword.Trim(), "md5");

             user.Password = hash;
             _membrepository.Save();

             return true;
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

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

    }
}
