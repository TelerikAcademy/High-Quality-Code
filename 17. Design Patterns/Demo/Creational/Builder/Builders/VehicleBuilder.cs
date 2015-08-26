namespace Builder.Builders
{
    /// <summary>
    /// The 'Builder' abstract class
    /// Specifies an abstract interface for creating parts of a Product object
    /// Concrete builders define and keep track of the representations they create
    /// </summary>
    public abstract class VehicleBuilder
    {
        /// <summary>
        /// Provides an interface for retrieving the product
        /// </summary>
        public Vehicle Vehicle { get; set; }

        public abstract void BuildFrame();

        public abstract void BuildEngine();

        public abstract void BuildWheels();

        public abstract void BuildDoors();
    }
}
