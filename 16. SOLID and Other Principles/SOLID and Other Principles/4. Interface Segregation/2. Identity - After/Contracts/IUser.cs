namespace InterfaceSegregationIdentityAfter.Contracts
{
    public interface IUser
    {
        string Email { get; }

        string PasswordHash { get; }
    }
}
