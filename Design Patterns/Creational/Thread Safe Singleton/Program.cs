namespace ThreadSafeSingleton
{
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            Parallel.For(0, 20, x => LazyThreadSafeLogger.Instance.SaveToLog(x));
            LazyThreadSafeLogger.Instance.PrintLog();
        }
    }
}
