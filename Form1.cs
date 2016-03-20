using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using SudokuSolver.Logic;
using SudokuSolver.Validators;

namespace SudokuSolver
{
    public partial class Form1 : Form
    {
        private int _size;

        public Form1()
        {
            InitializeComponent();
        }

        private void cmdGenerateSize_Click(object sender, EventArgs e)
        {

            _size = -1;

            //validate the user input
            try
            {
                Int32.TryParse(txtSize.Text, out _size);
                Validator.ValidateGridSize(_size);
            }
            catch (ValidationException v)
            {
                MessageBox.Show(v.Message);
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Something unexpected happened!");
                return;
            }

            dgvSudokuTable.Columns.Clear();

            for (int i = 0; i < _size; i++)
            {
                dgvSudokuTable.Columns.Add((i+1).ToString(), (i+1).ToString());
                dgvSudokuTable.Columns[i].Width = 20;
                dgvSudokuTable.Rows.Add();
            }
        }

        private void cmdSolve_Click(object sender, EventArgs e)
        {
            int currentNumber = -1;

            int[,] sudokuTable = new int[_size,_size];

            //extract the table from the datagridview
            for (int rows = 0; rows < dgvSudokuTable.Rows.Count; rows++)
            {
                for (int col = 0; col < dgvSudokuTable.Rows[rows].Cells.Count; col++)
                {

                    if (dgvSudokuTable.Rows[rows].Cells[col].Value == null)
                    {
                        sudokuTable[rows, col] = -1;
                    }
                    else
                    {
                        string value = dgvSudokuTable.Rows[rows].Cells[col].Value.ToString();

                        try
                        {
                            currentNumber = int.Parse(value);

                            if (currentNumber > _size)
                            {
                                throw new ValidationException("Sudoku table not valid! Allowed values are from 1 to " +
                                                              _size);
                            }

                        }
                        catch (ValidationException v)
                        {
                            MessageBox.Show(v.Message);
                            return;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(
                                "Something happened. Most likely you inserted a character instead of a number somewhere");
                            return;
                        }

                        sudokuTable[rows, col] = currentNumber;
                    }

                }
            }
            //end extraction of values from data grid view

            try
            {
                Validator.ValidateSudokuTable(sudokuTable);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            int[,] solution;

            if (rbBFS.Checked)
            {
                solution = Solver.FindSolution(sudokuTable);
            }
            else
            {
                solution = Solver.FindSolutionGBFS(sudokuTable);
            }


            if (solution == null)
            {
                MessageBox.Show("A solution has not been found!");
                return;
            }

            for (int rows = 0; rows < dgvSudokuTable.Rows.Count; rows++)
            {
                for (int col = 0; col < dgvSudokuTable.Rows[rows].Cells.Count; col++)
                {
                    dgvSudokuTable.Rows[rows].Cells[col].Value = solution[rows, col];
                }
            }
        }
    }
}
