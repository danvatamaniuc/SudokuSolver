using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Validators
{
    public class Validator
    {
        /// <summary>
        /// Checks if the size of the sudoku is a perfect square
        /// </summary>
        /// <param name="size">Has to be a positive integer bigger than 1</param>
        public static void ValidateGridSize(int size)
        {
            if (size < 2)
            {
                throw new ValidationException("Size is smaller than 2!");
            }

            double result = Math.Sqrt(size);
            if (!(result % 1).Equals(0))
            {
                throw new ValidationException("Number is not a perfect square!");
            }
        }

        public static void ValidateSudokuTable(int[,] sudokuTable)
        {
            HashSet<int> rowValues = new HashSet<int>();
            HashSet<int> columnValues = new HashSet<int>();

            //check for collisions on rows and columns
            int length = (int) Math.Sqrt(sudokuTable.Length);

            for (int rows = 0; rows < length; rows++)
            {
                rowValues.Clear();
                columnValues.Clear();

                for (int columns = 0; columns < length; columns++)
                {
                    if ( !rowValues.Add(sudokuTable[rows, columns]) && 
                            !sudokuTable[rows, columns].Equals(-1) 
                        )
                    {
                        throw new ValidationException("Conflict on row " + (rows + 1));
                    }
                }

                for (int columns = 0; columns < length; columns++)
                {
                    if ( !columnValues.Add(sudokuTable[columns, rows]) &&
                            !sudokuTable[columns, rows].Equals(-1) 
                       )
                    {
                        throw new ValidationException("Conflict on column " + (rows + 1));
                    }
                }

            }

            int squareSize = (int) Math.Sqrt(length);
            HashSet<int> squareSet = new HashSet<int>();

            //check for colisions in mini-squares
            for (int rows = 0; rows < length; rows += squareSize)
            {
                for (int columns = 0; columns < length; columns += squareSize)
                {
                    squareSet.Clear();

                    for (int squareRow = rows; squareRow < rows + squareSize; squareRow++)
                    {
                        for (int squareColumn = columns; squareColumn < columns + squareSize; squareColumn++)
                        {
                            if (!squareSet.Add(sudokuTable[squareRow, squareColumn]) &&
                                !sudokuTable[squareRow, squareColumn].Equals(-1)
                               )
                            {
                                throw new ValidationException("Conflict in square " + (rows / squareSize + columns / squareSize));
                            }
                        }
                    }
                }
            }
        }

        public static bool CheckIfSolution(int[,] potentialSolution)
        {
            for (int i = 0; i < Math.Sqrt(potentialSolution.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(potentialSolution.Length); j++)
                {
                    if (potentialSolution[i,j].Equals(-1))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        
    }
}
