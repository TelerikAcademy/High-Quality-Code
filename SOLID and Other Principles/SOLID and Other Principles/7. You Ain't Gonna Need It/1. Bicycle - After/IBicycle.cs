namespace YAGNIBicycleAfter
{
    public interface IBicycle
    {
        int Wheels { get; }

        int Seat { get; }

        string Body { get; }

        int Breaks { get; }

        string Chain { get; }

        string Steering { get; }
    }
}
