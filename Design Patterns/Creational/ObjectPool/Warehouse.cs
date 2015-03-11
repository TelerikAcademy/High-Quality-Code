namespace ObjectPool
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The Pool class is the most important class in the object pool design pattern. It controls access to the
    /// pooled objects, maintaining a list of available objects and a collection of objects that have already been
    /// requested from the pool and are still in use. The pool also ensures that objects that have been released
    /// are returned to a suitable state, ready for the next time they are requested.
    /// </summary>
    public class Warehouse<T> where T : IDisposable, new()
    {
        private List<T> availableEquipment = new List<T>();
        private List<T> usedEquipment = new List<T>();

        // We can define the size of the pool in constructor
        public Warehouse()
        {
        }

        public T GetEquipment()
        {
            lock (availableEquipment)
            {
                if (availableEquipment.Count != 0)
                {
                    var equipment = availableEquipment[0];
                    usedEquipment.Add(equipment);
                    availableEquipment.RemoveAt(0);
                    return equipment;
                }
                else
                {
                    var equipment = new T();
                    usedEquipment.Add(equipment);
                    return equipment;
                }
            }
        }

        public void ReleaseEquipment(T equipment)
        {
            equipment.Dispose();

            lock (availableEquipment)
            {
                availableEquipment.Add(equipment);
                usedEquipment.Remove(equipment);
            }
        }
    }
}
