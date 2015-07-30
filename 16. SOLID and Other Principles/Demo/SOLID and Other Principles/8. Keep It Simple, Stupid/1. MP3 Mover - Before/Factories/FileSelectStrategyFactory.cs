namespace KISSMp3MoverBefore.Factories
{
    using System;

    using KISSMp3MoverBefore.Contracts;
    using KISSMp3MoverBefore.Strategies.SelectStrategies;

    public class FileSelectStrategyFactory : IFileSelectStrategyFactory
    {
        public IFileSelectStrategy Get(string type)
        {
            switch (type)
            {
                case "ArtistDashSong": return new ArtistDashSongStrategy();
                default: throw new ArgumentException("Invalid move strategy");
            }
        }
    }
}
