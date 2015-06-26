using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{

	// smilih se nad vas kolegi, ne sym puskal obfuskatora, shtoto se zamislih, che i vie moze da imate
    class LabTest
    {
        static void Main()
        {
            Ladder ladder = new Ladder();
            Random rand = new Random();
            while (1 == 1)
            {


                Game game = new Game(rand, ladder);
            }
        }
    }
}
