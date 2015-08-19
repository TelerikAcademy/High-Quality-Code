namespace InterfaceSegregationIdentityBefore
{
    using InterfaceSegregationIdentityBefore.Contracts;

    public class AccountContoller
    {
        private readonly IAccount manager;

        public AccountContoller(IAccount manager)
        {
            this.manager = manager;
        }

        public void ChangePassword(string oldPass, string newPass)
        {
            this.manager.ChangePassword(oldPass, newPass);
        }
    }
}
