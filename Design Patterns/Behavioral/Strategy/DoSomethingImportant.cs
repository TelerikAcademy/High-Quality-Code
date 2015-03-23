namespace Strategy
{
    public class DoSomethingImportant
    {
        private readonly ILogger logger;

        public DoSomethingImportant(ILogger logger)
        {
            this.logger = logger;
        }

        public void DoTheJob()
        {
            this.logger.Log("Starting work...");
            this.logger.Log("Working...");
            this.logger.Log("Work done.");
        }
    }
}
