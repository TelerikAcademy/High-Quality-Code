namespace OpenClosedFileDownloadBefore
{
    public class Progress
    {
        private readonly File file;

        // If we want to stream a music file, we cannot
        public Progress(File file)
        {
            this.file = file;
        }

        public int CurrentPercent()
        {
            return this.file.Sent * 100 / this.file.Length;
        }
    }
}
