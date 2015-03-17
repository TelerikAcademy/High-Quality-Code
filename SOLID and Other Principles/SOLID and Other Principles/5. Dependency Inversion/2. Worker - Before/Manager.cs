namespace DependencyInversionWorkerBefore
{
    public class Manager
    {
        public void Manage()
        {
            var worker = new Worker();
            worker.Work();
        }
    }
}
