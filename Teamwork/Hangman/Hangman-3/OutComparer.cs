using System.Collections.Generic;

public class OutComparer : IComparer<KeyValuePair<string, int>>
{

    public int Compare(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
    {
        return x.Value.CompareTo(y.Value);
    }
}
