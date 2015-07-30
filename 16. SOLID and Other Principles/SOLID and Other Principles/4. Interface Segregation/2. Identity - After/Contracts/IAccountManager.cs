namespace InterfaceSegregationIdentityAfter.Contracts
{
    public interface IAccountManager
    {
        void ChangePassword(string oldPass, string newPass);
    }
}
