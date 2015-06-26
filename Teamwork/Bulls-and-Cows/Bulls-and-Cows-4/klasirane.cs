using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
//tova raboti - testvano e, NE PIPAJJJJ!!!!!!!!
    class klasirane<T> : IEnumerable<T>, IEnumerator<T> where T : IComparable<T>
    {
        private int maxCountOfStoredData;
        private T[] data;
        private int position = -1;

        private int count;
        public int Count
        {
            get { return this.count; }
        }

        public klasirane() : this(5) { }

        public klasirane(int aMaxCountOfStoredData)
        {
            maxCountOfStoredData = aMaxCountOfStoredData;
            data = new T[maxCountOfStoredData];
            count = 0;
        }

        public void Add(T item)
        {
            if (item.CompareTo(data[maxCountOfStoredData - 1]) >= 0)
            {
                int tPointer = 0;
                while (item.CompareTo(data[tPointer]) < 0)
                {
                    tPointer++;
                }

                for (int i = maxCountOfStoredData - 1; i > tPointer; i--)
                {
                    data[i] = data[i - 1];
                }

                data[tPointer] = item;
                if (count < maxCountOfStoredData)
                {
                    count++;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)this;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (IEnumerator<T>)this;
        }

        public T Current
        {
            get { return data[position]; }
        }

        public void Dispose()
        {
            this.Reset();
        }

        object System.Collections.IEnumerator.Current
        {
            get { return data[position]; }
        }

        public bool MoveNext()
        {
            if(position < Count - 1)
            {
                position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }      
}
