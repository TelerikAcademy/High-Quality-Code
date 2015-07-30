namespace InterfaceSegregationWorkerAfter
{
    using InterfaceSegregationWorkerAfter.Contracts;

    public class Human : IWorker, ISleeper, IEater
    {
        public void Eat()
        {
            // eat
        }

        public void Work()
        {
            // work
        }

        public void Sleep()
        {
            // sleep
        }
    }
}
