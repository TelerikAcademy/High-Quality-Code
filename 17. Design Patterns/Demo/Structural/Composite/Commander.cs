namespace CompositePattern
{
    using System;
    using System.Collections.Generic;

    public class Commander : PersonComponent
    {
        private readonly ICollection<PersonComponent> subjects;

        public Commander(string name)
            : base(name)
        {
            this.subjects = new List<PersonComponent>();
        }

        public void Add(PersonComponent person)
        {
            this.subjects.Add(person);
        }

        public void Remove(PersonComponent person)
        {
            this.subjects.Remove(person);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + this.Name);

            foreach (var person in this.subjects)
            {
                person.Display(depth + 4);
            }
        }
    }
}
