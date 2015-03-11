namespace FluentInterface
{
    using System;

    public class Customer
    {
        private readonly CustomerContext context = new CustomerContext();

        public Customer FirstName(string firstName)
        {
            this.context.FirstName = firstName;
            return this;
        }

        public Customer LastName(string lastName)
        {
            this.context.LastName = lastName;
            return this;
        }

        public Customer Gender(string gender)
        {
            this.context.Gender = gender;
            return this;
        }

        public Customer Address(string address)
        {
            this.context.Address = address;
            return this;
        }

        public void PrintToConsole()
        {
            Console.WriteLine("first name: {0} \nlast name: {1} \ngender: {2} \naddress: {3}", this.context.FirstName, this.context.LastName, this.context.Gender, this.context.Address);
        }
    }
}
