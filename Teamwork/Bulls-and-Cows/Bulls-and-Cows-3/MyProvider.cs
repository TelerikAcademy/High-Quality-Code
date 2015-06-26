using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kravi
{
    public class MyProvider : randomNumberProvider
    {
        public override string GetRandomNumber()
        {
            return "1234";// ((int)(rand.NextDouble() * 9000 + 1000)).ToString();
        }
    }
}
