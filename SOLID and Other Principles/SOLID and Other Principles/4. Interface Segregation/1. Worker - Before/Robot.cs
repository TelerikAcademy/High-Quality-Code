namespace InterfaceSegregationWorkerBefore
{
    using InterfaceSegregationWorkerBefore.Contracts;

    public class Robot : IWorker
    {
        public void Eat()
        {
            throw new System.NotImplementedException();
        }

        public void Work()
        {
            // work
        }

        public void Sleep()
        {
            throw new System.NotImplementedException();
        }
    }
}
