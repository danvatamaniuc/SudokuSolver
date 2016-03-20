using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.Validators;

namespace SudokuSolver.Logic.Tests
{
    [TestClass()]
    public class SolverTests
    {
        [TestMethod()]
        public void FindSolutionTest()
        {
            //usual 4x4 table
            try
            {
                int[,] sudokuTable = { {1,2,3,4}, {3,4,1,2}, {-1,-1,-1,-1}, {-1,-1,-1,-1} };
                Validator.ValidateSudokuTable(Solver.FindSolution(sudokuTable));
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            //usual 4x4 table with GBFS
            try
            {
                int[,] sudokuTable = { { 1, 2, 3, 4 }, { 3, 4, 1, 2 }, { -1, -1, -1, -1 }, { -1, -1, -1, -1 } };
                Validator.ValidateSudokuTable(Solver.FindSolutionGBFS(sudokuTable));
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            //row inconsistency
            int[,] sudokuTable1 = { { 2, 2, 1, 4 }, { 1, 4, 3, 2 }, { -1, -1, -1, -1 }, { -1, -1, -1, -1 } };
            Assert.IsNull(Solver.FindSolution(sudokuTable1));
            Assert.IsNull(Solver.FindSolutionGBFS(sudokuTable1));


            //column inconsistency
            int[,] sudokuTable2 = { { 1, 2, 3, 4 }, { 1, 3, 4, 2 }, { -1, -1, -1, -1 }, { -1, -1, -1, -1 } };
            Assert.IsNull(Solver.FindSolution(sudokuTable2));
            Assert.IsNull(Solver.FindSolutionGBFS(sudokuTable2));


            //square inconsistency
            int[,] sudokuTable3 = { { 2, 3, 1, -1 }, { 1, 2, 3, 4 }, { -1, -1, -1, -1 }, { -1, -1, -1, -1 } };
            Assert.IsNull(Solver.FindSolution(sudokuTable3));
            Assert.IsNull(Solver.FindSolutionGBFS(sudokuTable3));

        }
    }
}