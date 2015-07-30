namespace YAGNIBicycleBefore
{
    public interface IBicycle
    {
        int Wheels { get; }

        int Seat { get; }

        string Body { get; }

        int Breaks { get; }

        string Chain { get; }

        string Steering { get; }

        bool IsElectric { get; }

        string Engine { get; }

        string TypeOfFuel { get; }

        int AssistingWheels { get; }

        string Umbrella { get; }

        string GPS { get; }

        int Mirrors { get; }

        int Stickers { get; }

        int LuggageVolume { get; }
    }
}
