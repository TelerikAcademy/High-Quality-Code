namespace KISSMp3MoverBefore.Contracts
{
    public interface IFileRenameStrategyFactory
    {
        IFileRenameStrategy Get(string type);
    }
}
