namespace KISSMp3MoverBefore.Contracts
{
    public interface IFileMoveStrategy
    {
        void Move(string oldPath, string newPath);
    }
}
