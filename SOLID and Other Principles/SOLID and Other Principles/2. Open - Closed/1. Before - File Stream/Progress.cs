namespace OpenClosedFileDownloadBefore
{
    public class Progress
    {
        private File file;

        // if we want to stream a Music file, we cannot
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
