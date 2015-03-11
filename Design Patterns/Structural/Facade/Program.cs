namespace FacadePattern
{
    public class Program
    {
        public static void Main()
        {
            HomeTheaterPro es = HomeTheaterPro.CreateInstance();

            es.InitHomeSystem();
            es.Next();
            es.Next();
            es.Stop();
        }
    }
}
