namespace FacadePattern
{
    public static class Program
    {
        public static void Main()
        {
            var homeTheaterPro = HomeTheaterPro.CreateInstance();

            homeTheaterPro.InitHomeSystem();
            homeTheaterPro.Next();
            homeTheaterPro.Next();
            homeTheaterPro.Stop();
        }
    }
}
