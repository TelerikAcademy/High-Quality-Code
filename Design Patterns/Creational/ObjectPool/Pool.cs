namespace ObjectPool
{
    using System.Collections.Generic;

    /// <summary>
    /// The Pool class is the most important class in the object pool design pattern. It controls access to the
    /// pooled objects, maintaining a list of available objects and a collection of objects that have already been
    /// requested from the pool and are still in use. The pool also ensures that objects that have been released
    /// are returned to a suitable state, ready for the next time they are requested.
    /// </summary>
    public class Pool
    {
        private List<PooledObject> _available = new List<PooledObject>();
        private List<PooledObject> _inUse = new List<PooledObject>();

        // We can define the size of the pool in constructor
        public Pool()
        {
        }

        public PooledObject GetObject()
        {
            lock (_available)
            {
                if (_available.Count != 0)
                {
                    PooledObject po = _available[0];
                    _inUse.Add(po);
                    _available.RemoveAt(0);
                    return po;
                }
                else
                {
                    PooledObject po = new PooledObject();
                    _inUse.Add(po);
                    return po;
                }
            }
        }

        public void ReleaseObject(PooledObject po)
        {
            CleanUp(po);

            lock (_available)
            {
                _available.Add(po);
                _inUse.Remove(po);
            }
        }

        private void CleanUp(PooledObject po)
        {
            po.TempData = null;
        }
    }
}
