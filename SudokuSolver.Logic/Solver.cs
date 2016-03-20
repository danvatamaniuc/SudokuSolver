using System;
using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Validators;

namespace SudokuSolver.Logic
{
    public class Solver
    {
        private static int _size;
        private static int _squareSize;

        /// <summary>
        /// Generates a solution to a particular sudoku problem
        /// </summary>
        /// <param name="sudokuTable">a 2D array that represents a sudoku problem</param>
        /// <returns>A solution to the proposed problem</returns>
        public static int[,] FindSolution(int[,] sudokuTable)
        {
            Tail<int[,]> tail = new Tail<int[,]>();

            tail.Add(sudokuTable);
            _size = (int) Math.Sqrt(sudokuTable.Length);
            _squareSize = (int) Math.Sqrt(_size);

            while (true)
            {

                if (tail.Empty())
                {
                    break;
                }

                int[,] potentialSolution = tail.GetNext();

                if (Validator.CheckIfSolution(potentialSolution))
                {
                    return potentialSolution;
                }

                int firstEmptyX = 0;
                int firstEmptyY = 0;

                bool posFound = false;

                if (!potentialSolution[firstEmptyX, firstEmptyY].Equals(-1))
                {
                    for (int j = 0; j < _size; j++)
                    {
                        for (int k = 0; k < _size; k++)
                        {
                            if (potentialSolution[j, k].Equals(-1))
                            {
                                firstEmptyX = j;
                                firstEmptyY = k;
                                posFound = true;
                                break;
                            }
                        }

                        if (posFound)
                        {
                            break;
                        }
                    }
                }

                HashSet<int> possibleOptions = GetPossibleOptions(potentialSolution, firstEmptyX, firstEmptyY);

                foreach (int possibleOption in possibleOptions)
                {
                    int[,] potentialSolutionChild = (int[,])potentialSolution.Clone();
                    potentialSolutionChild[firstEmptyX, firstEmptyY] = possibleOption;
                    tail.Add(potentialSolutionChild);
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the possible numbers for insertion in a certain spot in a Sudoku table
        /// </summary>
        /// <param name="potentialSolution">The Sudoku table</param>
        /// <param name="firstEmptyX">X coord of the spot</param>
        /// <param name="firstEmptyY">Y coord of the spot</param>
        /// <returns>hash set of all the options</returns>
        private static HashSet<int> GetPossibleOptions(int[,] potentialSolution, int firstEmptyX, int firstEmptyY)
        {
            HashSet<int> options = new HashSet<int>();

            for (int i = 1; i <= _size; i++)
            {
                options.Add(i);
            }
            
            //eliminate options that cannot be inserted because of a row or a column
            for (int i = 0; i < Math.Sqrt(potentialSolution.Length); i++)
            {
                if (options.Contains(potentialSolution[firstEmptyX, i]))
                {
                    options.Remove(potentialSolution[firstEmptyX, i]);
                }

                if (options.Contains(potentialSolution[i, firstEmptyY]))
                {
                    options.Remove(potentialSolution[i, firstEmptyY]);
                }
            }

            //eliminate options that cannot be inserted because of the square
            int startX = firstEmptyX - firstEmptyX % _squareSize;
            int startY = firstEmptyY - firstEmptyY % _squareSize;

            

            for (int i = startX; i < startX + _squareSize; i++)
            {
                for (int j = startY; j < startY + _squareSize; j++)
                {
                    if (options.Contains(potentialSolution[i,j]))
                    {
                        options.Remove(potentialSolution[i, j]);
                    }
                }
            }

            return options;

        }

        public static int[,] FindSolutionGBFS(int[,] sudokuTable)
        {

            //too lazy to define a proper priority que
            Dictionary<int[,], int> tail = new Dictionary<int[,], int>();

            tail.Add(sudokuTable, 0);
            _size = (int)Math.Sqrt(sudokuTable.Length);
            _squareSize = (int)Math.Sqrt(_size);

            while (true)
            {

                if (tail.Count.Equals(0))
                {
                    break;
                }

                //priority que simulation

                var sortedSudokus = tail.ToList();

                sortedSudokus.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

                int[,] potentialSolution = sortedSudokus[0].Key;

                tail.Remove(potentialSolution);

                //

                if (Validator.CheckIfSolution(potentialSolution))
                {
                    return potentialSolution;
                }

                int firstEmptyX = 0;
                int firstEmptyY = 0;

                bool posFound = false;

                if (!potentialSolution[firstEmptyX, firstEmptyY].Equals(-1))
                {
                    for (int j = 0; j < _size; j++)
                    {
                        for (int k = 0; k < _size; k++)
                        {
                            if (potentialSolution[j, k].Equals(-1))
                            {
                                firstEmptyX = j;
                                firstEmptyY = k;
                                posFound = true;
                                break;
                            }
                        }

                        if (posFound)
                        {
                            break;
                        }
                    }
                }

                HashSet<int> possibleOptions = GetPossibleOptions(potentialSolution, firstEmptyX, firstEmptyY);
                Dictionary<int[,],int> dictionary = new Dictionary<int[,], int>();

                foreach (int possibleOption in possibleOptions)
                {
                    int[,] potentialSolutionChild = (int[,])potentialSolution.Clone();
                    potentialSolutionChild[firstEmptyX, firstEmptyY] = possibleOption;
                    dictionary.Add(potentialSolutionChild, SolutionValue(potentialSolutionChild));
                }

                foreach (KeyValuePair<int[,], int> sortedSudoku in dictionary)
                {
                    tail.Add(sortedSudoku.Key, sortedSudoku.Value);
                }

            }

            return null;
        }

        private static int SolutionValue(int[,] potentialSolutionChild)
        {
            int totalValue = 0;

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    totalValue += (GetPossibleOptions(potentialSolutionChild, i, j)).Count;
                }
            }

            return totalValue;
        }
    }
}
