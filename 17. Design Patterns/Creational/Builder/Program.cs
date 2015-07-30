namespace Builder
{
    public static class Program
    {
        public static void Main()
        {
            VehicleBuilder builder;

            // We can choose concrete constructor (director)
            var constructor = new VehicleConstructor();

            // And we can choose concrete builder
            builder = new ScooterBuilder();
            constructor.Construct(builder);
            builder.Vehicle.Show();

            builder = new CarBuilder();
            constructor.Construct(builder);
            builder.Vehicle.Show();

            builder = new MotorCycleBuilder();
            constructor.Construct(builder);
            builder.Vehicle.Show();
        }
    }
}
