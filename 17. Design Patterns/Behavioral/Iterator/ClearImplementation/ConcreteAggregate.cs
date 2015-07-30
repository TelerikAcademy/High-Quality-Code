namespace Iterator.ClearImplementation
{
    using System.Collections;

    /// <summary>
    /// The 'ConcreteAggregate' class
    /// </summary>
    public class ConcreteAggregate : Aggregate
    {
        private readonly ArrayList items = new ArrayList();

        // Gets item count
        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        // Indexer
        public object this[int index]
        {
            get
            {
                return this.items[index];
            }

            set
            {
                this.items.Insert(index, value);
            }
        }

        public override IIterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
    }
}
