namespace OpenClosedFileDownloadAfter.Contracts
{
    public interface IResult
    {
        int Length { get; set; }

        int Sent { get; set; }
    }
}
