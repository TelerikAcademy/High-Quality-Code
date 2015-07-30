namespace KISSMp3MoverBefore
{
    using System.IO;

    using KISSMp3MoverBefore.Contracts;

    public class Mp3Mover : IMp3Mover
    {
        private static IMp3Mover mp3MoverInstance;

        private Mp3Mover()
        {
        }

        public static IMp3Mover Instance
        {
            get
            {
                if (mp3MoverInstance == null)
                {
                    mp3MoverInstance = new Mp3Mover();
                }

                return mp3MoverInstance;
            }
        }

        public string DirectoryPath { private get; set; }

        public IFileSelectStrategy SelectStrategy { private get; set; }

        public IFileRenameStrategy RenameStrategy { private get; set; }

        public IFileMoveStrategy MoveStrategy { private get; set; }

        public void Start()
        {
            foreach (var fileName in Directory.EnumerateFiles(this.DirectoryPath))
            {
                if (this.SelectStrategy.CanBeSelected(fileName))
                {
                    this.RenameStrategy.Rename(fileName);
                    var artist = fileName.Substring(0, fileName.IndexOf(" - "));
                    this.MoveStrategy.Move(fileName, artist + "/" + fileName);
                }
            }
        }
    }
}
