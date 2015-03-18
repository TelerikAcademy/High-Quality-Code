namespace Iterator.ClearImplementation
{
    /// <summary>
    /// The 'ConcreteIterator' class
    /// </summary>
    public class ConcreteIterator : IIterator
    {
        private readonly ConcreteAggregate aggregate;

        private int current = 0;

        // Constructor
        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        // Gets next iteration item
        public void Next()
        {
            this.current++;
        }

        // Gets current iteration item
        public object CurrentItem()
        {
            return this.aggregate[this.current];
        }

        // Gets whether iterations are complete
        public bool IsDone()
        {
            return this.current >= this.aggregate.Count;
        }
    }
}
