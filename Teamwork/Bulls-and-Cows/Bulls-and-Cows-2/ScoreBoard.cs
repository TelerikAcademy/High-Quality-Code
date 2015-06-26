using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace bikove
{
    public class Scoreboard
    {
        private SortedSet<gameScore> scores;
        private const int MaxPlayersToShowInScoreboard = 10;

        public Scoreboard(string filename)
        {
            this.scores = new SortedSet<gameScore>();
            try
            {
                using (StreamReader inputStream = new StreamReader(filename))
                {
                    while (!inputStream.EndOfStream)
                    {
                        string scoreString = inputStream.ReadLine();
                        this.scores.Add(gameScore.Deserialize(scoreString));
                    }
                }
            }
            catch (IOException)
            {
                // Stop reading
            }
        }

        public void AddScore(string name, int guesses)
        {
            gameScore newScore = new gameScore(name, guesses);
            this.scores.Add(newScore);
        }

        public void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter outputStream = new StreamWriter(filename))
                {
                    foreach (gameScore gameScore in scores)
                    {
                        outputStream.WriteLine(gameScore.Serialize());
                    }
                }
            }
            catch (IOException)
            {
                // Stop writing
            }
        }

        public override string ToString()
        {
            if (scores.Count == 0)
            {
                return "Top scoreboard is empty." + Environment.NewLine;
            }
            StringBuilder scoreBoard = new StringBuilder();
            scoreBoard.AppendLine("Scoreboard:");
            int count = 0;
            foreach (gameScore gameScore in scores)
            {
                count++;
                scoreBoard.AppendLine(string.Format("{0}. {1}", count, gameScore));
                if (count > MaxPlayersToShowInScoreboard) break;
            }
            return scoreBoard.ToString();
        }
    }
}
