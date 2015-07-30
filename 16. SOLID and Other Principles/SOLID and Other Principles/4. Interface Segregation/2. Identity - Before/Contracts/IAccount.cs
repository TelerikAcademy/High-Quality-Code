namespace InterfaceSegregationIdentityBefore.Contracts
{
    using System.Collections.Generic;

    public interface IAccount
    {
        bool RequireUniqueEmail { get; set; }

        int MinRequiredPasswordLength { get; set; }

        int MaxRequiredPasswordLength { get; set; }

        void Register(string username, string password);

        void Login(string username, string password);

        void ChangePassword(string oldPass, string newPass);

        IEnumerable<IUser> GetAllUsersOnline();

        IEnumerable<IUser> GetAllUsers();

        IUser GetUserByName(string name);
    }
}
