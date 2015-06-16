namespace Computers.Common.Factories
{
    public interface IComputerFactory
    {
        Pc CreatePc();

        Server CreateServer();

        Laptop CreateLaptop();
    }
}
