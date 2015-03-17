namespace InterfaceSegregationIdentityAfter.Contracts
{
    public interface IAccountSettings
    {
        bool RequireUniqueEmail { get; set; }

        int MinRequiredPasswordLength { get; set; }

        int MaxRequiredPasswordLength { get; set; }
    }
}
