namespace DependencyInversionWorkerAfter
{
    using DependencyInversionWorkerAfter.Contracts;

    public class Manager
    {
        private readonly IWorker worker;

        public Manager(IWorker worker)
        {
            this.worker = worker;
        }

        public void Manage()
        {
            this.worker.Work();
        }
    }
}
