namespace KISSMp3MoverBefore.Contracts
{
    public interface IFileSelectStrategy
    {
        bool CanBeSelected(string fileName);
    }
}
