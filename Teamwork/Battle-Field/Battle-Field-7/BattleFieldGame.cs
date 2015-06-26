using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BattleFieldNamespace
{
    class BattleField : BattleGame // tuka naslediavame osbhtata igra i pravilata
    {
        
        static void Main(string[] args)
        {
            BattleField BF=new BattleField();

            BF.Start();
        }
    }
}
