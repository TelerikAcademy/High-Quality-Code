namespace DependencyInversionHelloWorldBefore
{
    using System;

    public class HelloWorld
    {
        public string Greet(string name)
        {
            if (DateTime.Now.Hour < 12)
            {
                return "Good morning, " + name;
            }

            if (DateTime.Now.Hour < 18)
            {
                return "Good afternoon, " + name;
            }

            return "Good evening, " + name;
        }
    }
}
