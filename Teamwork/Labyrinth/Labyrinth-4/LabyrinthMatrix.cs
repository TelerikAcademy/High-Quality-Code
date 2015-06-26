using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class LabyrinthMatrix
    {
        private char[][] matrix;
        private int myPostionVertical;
        private int myPostionHorizontal;
        private Random random = new Random();
        public LabyrinthMatrix()
        {
            myPostionHorizontal = 3;
            myPostionVertical = 3;
            matrix = new char[7][];



            for (int i = 0; i <matrix.Length; i++)
            {
                matrix[i] = new char[7];
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = GetRandomSymbol();
                }
            }

            matrix[3][3] = '-';
        }
        public LabyrinthMatrix(LabyrinthMatrix l)
        {

        }

        private char GetRandomSymbol() 
        {
           
            int random1 = random.Next(0,2);
            if (random1 == 1)
            {


                return 'X';
            }
            else
            {
                return '-';
            }
        }
        public char[][] Matrix 
        {
            get 
            {
                return matrix;
            }
        }
        public int MyPostionVertical 
        {
            get 
            {
                return this.myPostionVertical;
            }
            set 


            {
                this.myPostionVertical = value;
            }
        }
        public int MyPostionHorizontal 
        {
            get 
            {
                return this.myPostionHorizontal;
            }
            set 
            {
                this.myPostionHorizontal = value;
            }
        }
    }
}
