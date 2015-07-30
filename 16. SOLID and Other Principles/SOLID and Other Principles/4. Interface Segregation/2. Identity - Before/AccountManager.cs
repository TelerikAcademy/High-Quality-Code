namespace InterfaceSegregationIdentityBefore
{
    using System.Collections.Generic;

    using InterfaceSegregationIdentityBefore.Contracts;

    public class AccountManager : IAccount
    {
        public bool RequireUniqueEmail { get; set; }

        public int MinRequiredPasswordLength { get; set; }

        public int MaxRequiredPasswordLength { get; set; }

        public void Register(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public void Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public void ChangePassword(string oldPass, string newPass)
        {
            // change password
        }

        public IEnumerable<IUser> GetAllUsersOnline()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public IUser GetUserByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
