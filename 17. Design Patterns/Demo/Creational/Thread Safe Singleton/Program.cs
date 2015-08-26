namespace ThreadSafeSingleton
{
    using System.Threading.Tasks;

    public static class Program
    {
        public static void Main()
        {
            Parallel.For(0, 6, x => LazyThreadSafeLogger.Instance.SaveToLog(x));
            LazyThreadSafeLogger.Instance.PrintLog();
        }
    }
}
