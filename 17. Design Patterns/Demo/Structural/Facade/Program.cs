namespace FacadePattern
{
    public static class Program
    {
        public static void Main()
        {
            var homeTheaterPro = HomeTheaterPro.CreateInstance();
            homeTheaterPro.InitHomeSystem();
            homeTheaterPro.DisplayAvailableMedia();
            homeTheaterPro.Next();
            homeTheaterPro.Next();
            homeTheaterPro.Previous();
            homeTheaterPro.Stop();
        }
    }
}
