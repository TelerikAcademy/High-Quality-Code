namespace KISSMp3MoverBefore.Strategies.MoveStrategies
{
    using System.IO;

    using KISSMp3MoverBefore.Contracts;

    public class NormalMoveStrategy : IFileMoveStrategy
    {
        public void Move(string oldPath, string newPath)
        {
            File.Move(oldPath, newPath);
        }
    }
}
