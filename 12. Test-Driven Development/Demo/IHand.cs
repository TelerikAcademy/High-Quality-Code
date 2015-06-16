using System;
using System.Collections.Generic;

namespace Poker
{
    public interface IHand
    {
        IList<ICard> Cards { get; }
        string ToString();
    }
}
