using System.Threading;
namespace ObjectPool
{
    public class Program
    {
        public static void Main()
        {
            var objectPool = new Pool();

            var obj1 = objectPool.GetObject();
            System.Console.WriteLine("Object 1 {0:MM/dd/yyyy hh:mm:ss.fff tt}", obj1.CreatedAt);
            Thread.Sleep(1000);

            var obj2 = objectPool.GetObject();
            System.Console.WriteLine("Object 2 {0:MM/dd/yyyy hh:mm:ss.fff tt}", obj2.CreatedAt);
            Thread.Sleep(1000);
            
            objectPool.ReleaseObject(obj1);

            var obj3 = objectPool.GetObject();
            System.Console.WriteLine("Object 3 {0:MM/dd/yyyy hh:mm:ss.fff tt}", obj3.CreatedAt);
            Thread.Sleep(1000);
        }
    }
}
