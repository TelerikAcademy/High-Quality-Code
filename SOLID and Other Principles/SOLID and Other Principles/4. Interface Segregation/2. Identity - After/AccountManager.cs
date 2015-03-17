namespace InterfaceSegregationIdentityAfter
{
    using InterfaceSegregationIdentityAfter.Contracts;

    public class AccountManager : IAccountManager
    {
        public void ChangePassword(string oldPass, string newPass)
        {
            // change password
        }
    }
}
