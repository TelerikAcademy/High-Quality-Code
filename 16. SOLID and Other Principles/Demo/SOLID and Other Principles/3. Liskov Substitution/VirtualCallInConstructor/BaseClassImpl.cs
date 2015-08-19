namespace SOLID_and_Other_Principles._3._Liskov_Substitution.VirtualCallInConstructor
{
    public class BaseClassImpl : BaseClass
    {
        private readonly DatabaseRepository databaseRepository;

        public BaseClassImpl()
        {
            this.databaseRepository = new DatabaseRepository();
        }

        protected override void AddToDatabase()
        {
            this.databaseRepository.Add();
        }
    }
}