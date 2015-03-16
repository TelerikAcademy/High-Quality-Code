namespace Command.SwitchExample
{
    /// <summary>
    /// An interface that defines actions that the receiver can perform
    /// </summary>
    public interface ISwitchable
    {
        void PowerOn();

        void PowerOff();
    }
}
