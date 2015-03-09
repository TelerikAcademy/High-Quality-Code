namespace SimpleFactory
{
    public static class SimpleFactory
    {
        public static Employee GetEmployee(int workerNumber)
        {
            switch (workerNumber)
            {
                case 0:
                    return new Manager();
                case 1:
                case 2:
                    return new Developer();
                default:
                    return new Employee();
            }
        }
    }
}
