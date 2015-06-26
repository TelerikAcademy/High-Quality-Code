using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MinesweeperProject
{
    class MinesweeperGame
    {
        private MinesweeperGrid grid;
        private int score;
        private List<ScoreRecord> scoreBoard;

        public List<ScoreRecord> ScoreBoard
        {
            get
            {
                return scoreBoard;
            }
            set
            {
                scoreBoard = value;
            }
        }

        public int Score 
        { 
            get
            {
                return score;
            } 
            set
            {
                score = value;
            } 
        }

        public MinesweeperGrid Grid
        {
            get
            {
                return grid;
            }
        }
        
        public MinesweeperGame(int rows, int columns, int minesCount)
        {
            grid = new MinesweeperGrid(rows, columns, minesCount);
            scoreBoard = new List<ScoreRecord>();
        }

        public virtual void Start()
        {
            Grid.Reset();
            Score = 0;
        }

    }
}











