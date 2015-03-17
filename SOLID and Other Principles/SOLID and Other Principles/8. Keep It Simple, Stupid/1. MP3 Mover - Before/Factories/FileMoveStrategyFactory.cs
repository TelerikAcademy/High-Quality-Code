namespace KISSMp3MoverBefore.Factories
{
    using System;
    using KISSMp3MoverBefore.Contracts;
    using KISSMp3MoverBefore.Strategies.MoveStrategies;

    public class FileMoveStrategyFactory : IFileMoveStrategyFactory
    {
        public IFileMoveStrategy Get(string type)
        {
            switch (type)
            {
                case "Normal": return new NormalMoveStrategy();
                default: throw new ArgumentException("Invalid move strategy");
            }
        }
    }
}
