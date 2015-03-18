namespace Iterator.ClearImplementation
{
    /// <summary>
    /// The 'Iterator' abstract class / interface
    /// </summary>
    public interface IIterator
    {
        void Next();

        bool IsDone();

        object CurrentItem();
    }
}
