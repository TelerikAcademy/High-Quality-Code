namespace LazyInitialization
{
    using System.Collections.Generic;

    /// <summary>
    /// Standard type of object that will be constructed
    /// </summary>
    public struct LazyObject
    {
        public LazyObjectType Name;
        public IList<int> Result;
    }
}
