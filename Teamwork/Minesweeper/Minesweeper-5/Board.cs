using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Board
    {
        public Board(int rows, int columns, int minesCount)
        {
            random = new Random();
            this.rows = rows;
            this.columns = columns;
            this.minesCount = minesCount;
            this.fields = new Field[rows][];
            for (int i = 0; i < this.fields.Length; i++)
            {
                this.fields[i] = new Field[columns];
            }
            for (int i = 0; i < fields.Length; i++)
            {
                for (int j = 0; j < this.fields[i].Length; j++)
                {
                    this.fields[i][j] = new Field();
                }
            }
            this.SetMines();
        }

        private int rows;
        private int columns;
        private int minesCount;
        private Field[][] fields;
        private Random random;

        public enum Status { SteppedOnAMine, AlreadyOpened, SuccessfullyOpened, AllFieldsAreOpened }

        private int GenerateRandomNumber(int minValue, int maxValue)
        {
            int number = random.Next(minValue, maxValue);
            return number;
        }

        private int ScanSurroundingFields(int row, int column)
        {
            int mines = 0;
            if ((row > 0) &&
                (column > 0) &&
                (this.fields[row - 1][column - 1].Status == Field.FieldStatus.IsAMine))
            {
                mines++;
            }
            if ((row > 0) &&
                (this.fields[row - 1][column].Status == Field.FieldStatus.IsAMine))
            {
                mines++;
            }
            if ((row > 0) &&
                (column < this.columns - 1) &&
                (this.fields[row - 1][column + 1].Status == Field.FieldStatus.IsAMine))
            {
                mines++;
            }
            if ((column > 0) &&
                (this.fields[row][column - 1].Status == Field.FieldStatus.IsAMine))
            {
                mines++;
            }
            if ((column < this.columns - 1) &&
                (this.fields[row][column + 1].Status == Field.FieldStatus.IsAMine))
            {
                mines++;
            }
            if ((row < this.rows - 1) &&
                (column > 0) &&
                (this.fields[row + 1][column - 1].Status == Field.FieldStatus.IsAMine))
            {
                mines++;
            }
            if ((row < this.rows - 1) &&
                (this.fields[row + 1][column].Status == Field.FieldStatus.IsAMine))
            {
                mines++;
            }
            if ((row < this.rows - 1) &&
                (column < this.columns - 1) &&
                (this.fields[row + 1][column + 1].Status == Field.FieldStatus.IsAMine))
            {
                mines++;
            }
            return mines;
        }

        private void SetMines()
        {
            for (int i = 0; i < this.minesCount; i++)
            {
                int row = this.GenerateRandomNumber(0, this.rows);
                int column = this.GenerateRandomNumber(0, this.columns);
                if (this.fields[row][column].Status == Field.FieldStatus.IsAMine)
                {
                    i--;
                }
                else
                {
                    this.fields[row][column].Status = Field.FieldStatus.IsAMine;
                }
            }
        }

        private bool CheckIfWin()
        {
            int openedFields = 0;
            for (int i = 0; i < this.fields.Length; i++)
            {
                for (int j = 0; j < this.fields[i].Length; j++)
                {
                    if (this.fields[i][j].Status == Field.FieldStatus.Opened)
                    {
                        openedFields++;
                    }
                }
            }
            if ((openedFields + this.minesCount) == (this.rows * this.columns))
            {
                return true;
            }
            return false;
        }

        public void PrintGameBoard()
        {
            Console.Write("    ");
            for (int i = 0; i < this.columns; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.Write("   _");
            for (int i = 0; i < this.columns; i++)
            {
                Console.Write("__");
            }
            Console.WriteLine();

            for (int i = 0; i < this.rows; i++)
            {
                Console.Write(i);
                Console.Write(" | ");
                for (int j = 0; j < this.columns; j++)
                {
                    Field currentField = this.fields[i][j];
                    if (currentField.Status == Field.FieldStatus.Opened)
                    {
                        Console.Write(this.fields[i][j].Value);
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("? ");
                    }
                }
                Console.WriteLine("|");
            }

            Console.Write("   _");
            for (int i = 0; i < this.columns; i++)
            {
                Console.Write("__");
            }
            Console.WriteLine();
        }

        public Status OpenField(int row, int column)
        {
            Field field = this.fields[row][column];
            Status status;

            if (field.Status == Field.FieldStatus.IsAMine)
            {
                status = Status.SteppedOnAMine;
            }
            else if (field.Status == Field.FieldStatus.Opened)
            {
                status = Status.AlreadyOpened;
            }
            else
            {
                field.Value = this.ScanSurroundingFields(row, column);
                field.Status = Field.FieldStatus.Opened;
                if (CheckIfWin())
                {
                    status = Status.AllFieldsAreOpened;
                }
                else
                {
                    status = Status.SuccessfullyOpened;
                }
            }
            return status;
        }

        public void PrintAllFields()
        {
            Console.Write("    ");
            for (int i = 0; i < this.columns; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.Write("   _");
            for (int i = 0; i < this.columns; i++)
            {
                Console.Write("__");
            }
            Console.WriteLine();

            for (int i = 0; i < this.rows; i++)
            {
                Console.Write(i);
                Console.Write(" | ");
                for (int j = 0; j < this.columns; j++)
                {
                    Field currentField = this.fields[i][j];
                    if (currentField.Status == Field.FieldStatus.Opened)
                    {
                        Console.Write(this.fields[i][j].Value + " ");
                    }
                    else if (currentField.Status == Field.FieldStatus.IsAMine)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        currentField.Value = this.ScanSurroundingFields(i, j);
                        Console.Write(this.fields[i][j].Value + " ");
                    }
                }
                Console.WriteLine("|");
            }

            Console.Write("   _");
            for (int i = 0; i < this.columns; i++)
            {
                Console.Write("__");
            }
            Console.WriteLine();
        }

        public int CountOpenedFields()
        {
            int count = 0;
            for (int i = 0; i < this.fields.Length; i++)
            {
                for (int j = 0; j < this.fields[i].Length; j++)
                {
                    if (this.fields[i][j].Status == Field.FieldStatus.Opened)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
