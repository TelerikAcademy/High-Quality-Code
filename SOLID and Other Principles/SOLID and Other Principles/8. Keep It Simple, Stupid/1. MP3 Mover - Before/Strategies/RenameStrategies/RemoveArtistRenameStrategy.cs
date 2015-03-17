namespace KISSMp3MoverBefore.Strategies.RenameStrategies
{
    using System.IO;
    using KISSMp3MoverBefore.Contracts;

    public class RemoveArtistRenameStrategy : IFileRenameStrategy
    {
        public void Rename(string fileName)
        {
            File.Move(fileName, fileName.Substring(fileName.IndexOf(" - ") + 3));
        }
    }
}
