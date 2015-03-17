namespace KISSMp3MoverAfter
{
    using System.IO;

    public static class Mp3Mover
    {
        public static void Main()
        {
            const string DirectoryPath = @"C:\MyMusic\";

            foreach (var fileName in Directory.EnumerateFiles(DirectoryPath))
            {
                if (fileName.IndexOf(" - ") >= 0 && fileName.ToLower().EndsWith("mp3"))
                {
                    File.Move(fileName, fileName.Substring(fileName.IndexOf(" - ") + 3));
                    var artist = fileName.Substring(0, fileName.IndexOf(" - "));
                    File.Move(fileName, artist + "/" + fileName);
                }
            }
        }
    }
}
