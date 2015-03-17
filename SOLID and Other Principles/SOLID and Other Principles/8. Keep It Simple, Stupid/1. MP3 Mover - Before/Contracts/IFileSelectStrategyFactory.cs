namespace KISSMp3MoverBefore.Contracts
{
    public interface IFileSelectStrategyFactory
    {
        IFileSelectStrategy Get(string type);
    }
}
