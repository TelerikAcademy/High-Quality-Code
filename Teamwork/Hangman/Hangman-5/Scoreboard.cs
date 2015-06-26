using System;
using System.Collections.Generic;

class Scoreboard
{
    private const int MAX_NUMBER_OF_RECORDS = 5;
    private List<KeyValuePair<int, String>> TopFiveRecords;

    public Scoreboard()
    {
        this.TopFiveRecords = new List<KeyValuePair<int, string>>();
    }

    public void TryToSignToScoreboard(int numberOfMistakesMade)
    {
        bool scoreQualifiesForTopFive = CheckIfScoreQualifiesForTopFive(numberOfMistakesMade);
        if (scoreQualifiesForTopFive)
        {
                AddNewRecord(numberOfMistakesMade);
                PrintCurrentScoreboard();
        }
    }

    private bool CheckIfScoreQualifiesForTopFive(int numberOfMistakesMade)
    {
        bool scoreQualifiesForTopFive = false;
        if (TopFiveRecords.Count < MAX_NUMBER_OF_RECORDS)
        {
            scoreQualifiesForTopFive = true;
        }
        else
        {
            int worstScoreInTopFive = TopFiveRecords[MAX_NUMBER_OF_RECORDS - 1].Key;
            if (numberOfMistakesMade < worstScoreInTopFive)
            {
                scoreQualifiesForTopFive = true;
            }
        }
        return scoreQualifiesForTopFive;
    }

    private void AddNewRecord(int numberOfMistakesMade)
    {
        if (TopFiveRecords.Count == MAX_NUMBER_OF_RECORDS)
        {
            DeleteTheWorstRecord();
        }

        string playerName = AskForPlayerName();
        KeyValuePair<int, string> newRecord = new KeyValuePair<int, string>(numberOfMistakesMade, playerName);
        TopFiveRecords.Add(newRecord);
        SortRecordsAscendingByScore();
    }

    private string AskForPlayerName()
    {
        string name = "unknown";
        bool inputIsAcceptable = false;
        while (!inputIsAcceptable)
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string line = Console.ReadLine();
            if (line.Length == 0)
            {
                Console.WriteLine("You did not enter a name. Please, try again.");
            }
            else if (line.Length > 40)
            {
                Console.WriteLine("The name you entered is too long. Please, enter a name up to 40 characters");
            }
            else
            {
                name = line;
                inputIsAcceptable = true;
            }
        }
        return name;
    }

    private void DeleteTheWorstRecord()
    {
        this.TopFiveRecords.RemoveAt(TopFiveRecords.Count - 1);
    }

    private void SortRecordsAscendingByScore()
    {
        TopFiveRecords.Sort(CompareByKeys);
    }

    private static int CompareByKeys(KeyValuePair<int, string> pairA, KeyValuePair<int, string> pairB)
    {
        return pairA.Key.CompareTo(pairB.Key);
    }

    public void PrintCurrentScoreboard()
    {
        Console.WriteLine("Scoreboard:");
        if (TopFiveRecords.Count == 0)
        {
            Console.WriteLine("There are no records in the scoreboard yet.");
        }
        else
        {
            for (int index = 0; index < TopFiveRecords.Count; index++)
            {
                string name = TopFiveRecords[index].Value;
                int mistakes = TopFiveRecords[index].Key;
                Console.WriteLine("{0}. {1} --> {2} mistakes", index + 1, name, mistakes);
            }
        }
    }

}
