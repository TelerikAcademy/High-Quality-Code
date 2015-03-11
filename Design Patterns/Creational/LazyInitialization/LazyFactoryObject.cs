namespace LazyInitialization
{
    using System.Collections.Generic;

    /// <summary>
    /// Source http://en.wikipedia.org/wiki/Lazy_initialization
    /// </summary>
    public class LazyFactoryObject
    {
        // internal collection of items
        // IDictionary makes sure they are unique
        private IDictionary<LazyObjectType, LazyObject> _LazyObjectList =
            new Dictionary<LazyObjectType, LazyObject>();


        public LazyObject GetLazyFactoryObject(LazyObjectType name)
        {
            LazyObject noGoodSomeOne;

            // retrieves LazyObjectType from list via out, else creates one and adds it to list
            if (!_LazyObjectList.TryGetValue(name, out noGoodSomeOne))
            {
                noGoodSomeOne = new LazyObject();
                noGoodSomeOne.Name = name;
                noGoodSomeOne.Result = this.Result(name);

                _LazyObjectList.Add(name, noGoodSomeOne);
            }

            return noGoodSomeOne;
        }

        // takes type and create 'expensive' list
        private IList<int> Result(LazyObjectType name)
        {
            IList<int> result = null;

            switch (name)
            {
                case LazyObjectType.Small:
                    result = CreateSomeExpensiveList(1, 100);
                    break;
                case LazyObjectType.Big:
                    result = CreateSomeExpensiveList(1, 1000);
                    break;
                case LazyObjectType.Bigger:
                    result = CreateSomeExpensiveList(1, 10000);
                    break;
                case LazyObjectType.Huge:
                    result = CreateSomeExpensiveList(1, 100000);
                    break;
                case LazyObjectType.None:
                    result = null;
                    break;
                default:
                    result = null;
                    break;
            }

            return result;
        }

        // not an expensive item to create, but you get the point
        // delays creation of some expensive object until needed
        private IList<int> CreateSomeExpensiveList(int start, int end)
        {
            IList<int> result = new List<int>();

            for (int counter = 0; counter < (end - start); counter++)
            {
                result.Add(start + counter);
            }

            return result;
        }
    }
}
