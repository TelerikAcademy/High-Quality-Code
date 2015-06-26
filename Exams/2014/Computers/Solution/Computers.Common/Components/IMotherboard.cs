namespace Computers.Common.Components
{
    /// <summary>
    /// Represents mediator for all the main computer components.
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Gets the currently stored value in the RAM
        /// </summary>
        /// <returns>Returns the currently stored value in the RAM</returns>
        int LoadRamValue();

        /// <summary>
        /// Sets the currently stored value in the RAM
        /// </summary>
        /// <param name="value">The value to be stored in the RAM</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draws the string data on the video card
        /// </summary>
        /// <param name="data">The data to be drawn on the video card</param>
        void DrawOnVideoCard(string data);
    }
}
