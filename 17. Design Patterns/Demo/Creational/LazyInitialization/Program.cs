namespace LazyInitialization
{
    using System;
    using System.IO;

    using LazyInitialization.VirtualProxy;

    public static class Program
    {
        public static void Main()
        {
            var lazyFactoryObject = new LazyFactoryObject();
            var list = lazyFactoryObject.GetLazyFactoryObject(LazyObjectType.Big);
            Console.WriteLine(list.Result.Count);

            Console.WriteLine(new string('-', 60));

            var lazyInit = new Lazy<StreamReader>(() => new StreamReader("LazyInitialization.exe.config"));
            if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
            {
                var result = lazyInit.Value.ReadToEnd();
                Console.WriteLine(result);
            }

            Console.WriteLine(new string('-', 60));
            var db = new DataContext();
            var user = db.GetUserById(1337);
            Console.WriteLine(user.Roles.Count);
        }
    }
}
