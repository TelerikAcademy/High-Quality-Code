namespace SOLID_and_Other_Principles._3._Liskov_Substitution.VirtualCallInConstructor
{
    public abstract class BaseClass
    {
        protected BaseClass()
        {
            this.AddToDatabase();
        }

        protected virtual void AddToDatabase()
        {
        }
    }
}
