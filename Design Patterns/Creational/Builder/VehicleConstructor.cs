namespace Builder
{
    /// <summary>
    /// The 'Director' class
    /// Constructs an object using the Builder interface
    /// </summary>
    public class VehicleConstructor
    {
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }
}
