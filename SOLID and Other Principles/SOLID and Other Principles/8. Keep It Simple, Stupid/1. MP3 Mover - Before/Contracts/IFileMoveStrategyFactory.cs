namespace KISSMp3MoverBefore.Contracts
{
    public interface IFileMoveStrategyFactory
    {
        IFileMoveStrategy Get(string type);
    }
}
