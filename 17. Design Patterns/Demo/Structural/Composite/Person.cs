namespace CompositePattern
{
    using System;

    public class Person : PersonComponent
    {
        public Person(string name)
            : base(name)
        {
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + this.Name);
        }
    }
}