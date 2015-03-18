namespace Memento
{
    /// <summary>
    /// The 'Caretaker' class
    /// </summary>
    public class ProspectMemory
    {
        // May save more than one memento
        // (e.g. Stack for undo/redo functionality)
        public Memento Memento { get; set; }
    }
}
