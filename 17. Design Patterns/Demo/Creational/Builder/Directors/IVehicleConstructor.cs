namespace Builder
{
    using Builder.Builders;

    public interface IVehicleConstructor
    {
        void Construct(VehicleBuilder vehicleBuilder);
    }
}
