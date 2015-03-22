namespace ObjectPool
{
    using System;

    /// <summary>
    /// The PooledObject class is the type that is expensive or slow to instantiate, or that has limited availability, so is to be held in the object pool.
    /// </summary>
    public class Equipment : IDisposable
    {
        private readonly DateTime orderedAt = DateTime.Now;

        public DateTime OrderedAt
        {
            get { return this.orderedAt; }
        }

        public string EmployeeName { get; set; }

        public void Dispose()
        {
            this.EmployeeName = null;
        }
    }
}
