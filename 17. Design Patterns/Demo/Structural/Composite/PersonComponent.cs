namespace CompositePattern
{
    public abstract class PersonComponent
    {
        protected PersonComponent(string name)
        {
            this.Name = name;
        }

        protected string Name { get; private set; }

        public abstract void Display(int depth);
    }
}
