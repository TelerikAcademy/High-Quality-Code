namespace Builder
{
    using Builder.Builders;
    using Builder.Directors;

    public static class Program
    {
        public static void Main()
        {
            // We can choose concrete constructor (director)
            IVehicleConstructor constructor = new VehicleConstructor();

            // And we can choose concrete builder
            VehicleBuilder builder = new ScooterBuilder();
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
