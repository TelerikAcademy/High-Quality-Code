namespace TemplatesExample
{
    using System;
    using System.IO;

    public static class Program
    {
        public static void Main()
        {
            var myClass = new MyClass { Item5 = 213 };
            Console.WriteLine(myClass.Item5);

            var dataFileContent = File.ReadAllText("Data.xml");
            Console.WriteLine(dataFileContent);
        }
    }
}
