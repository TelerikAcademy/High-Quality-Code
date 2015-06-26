using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class Top5Scoreboard
    {
        #region Fields

        List<Tuple<uint, String>> scoreboard;

        #endregion

        public Top5Scoreboard()
        {
            scoreboard = new List<Tuple<uint, string>>();
        }

        public void HandleScoreboard(uint moveCount)
        {
            if (scoreboard.Count() >= 5 && moveCount > scoreboard.Last().Item1)
            {
                Console.WriteLine("Your not good enough for the scoreboard :)");
                return;
            }

            if (scoreboard.Count == 0 ||
                (scoreboard.Count < 5) && scoreboard.Last().Item1 < moveCount)
            {
                String nickname = ShowScoreboardInMessage();
                scoreboard.Add(new Tuple<uint, string>(moveCount, nickname));
                this.ShowScoreboard();
                return;
            }

            for (int i = 0; i < scoreboard.Count(); ++i)
            {
                if (moveCount <= scoreboard[i].Item1)
                {
                    String nickname = ShowScoreboardInMessage();
                    scoreboard.Insert(i, new Tuple<uint, string>(moveCount, nickname));
                    if (scoreboard.Count > 5)
                    {
                        scoreboard.Remove(scoreboard.Last());
                    }
                    this.ShowScoreboard();
                    break;
                }
            }
        }

        private String ShowScoreboardInMessage()
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            String nickname = Console.ReadLine();
            return nickname;
        }

        public void ShowScoreboard()
        {
            if (scoreboard.Count == 0)
            {
                Console.WriteLine("The scoreboard is empty.");
                return;
            }

            for (int i = 0; i < scoreboard.Count; ++i)
            {
                Console.WriteLine(  (i+1).ToString() + 
                                    ". " +
                                    scoreboard[i].Item2 +
                                    " --> " + 
                                    scoreboard[i].Item1.ToString() +
                                    " moves.");
            }
        }
    }
}
