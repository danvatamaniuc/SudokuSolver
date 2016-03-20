namespace SudokuSolver
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSize = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.dgvSudokuTable = new System.Windows.Forms.DataGridView();
            this.cmdGenerateSize = new System.Windows.Forms.Button();
            this.cmdSolve = new System.Windows.Forms.Button();
            this.rbBFS = new System.Windows.Forms.RadioButton();
            this.rbGBFS = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSudokuTable)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(13, 13);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(84, 13);
            this.lblSize.TabIndex = 0;
            this.lblSize.Text = "Marimea tabelei:";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(103, 10);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(100, 20);
            this.txtSize.TabIndex = 1;
            // 
            // dgvSudokuTable
            // 
            this.dgvSudokuTable.AllowUserToAddRows = false;
            this.dgvSudokuTable.AllowUserToDeleteRows = false;
            this.dgvSudokuTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSudokuTable.Location = new System.Drawing.Point(16, 36);
            this.dgvSudokuTable.Name = "dgvSudokuTable";
            this.dgvSudokuTable.RowHeadersWidth = 18;
            this.dgvSudokuTable.Size = new System.Drawing.Size(478, 304);
            this.dgvSudokuTable.TabIndex = 2;
            // 
            // cmdGenerateSize
            // 
            this.cmdGenerateSize.Location = new System.Drawing.Point(210, 10);
            this.cmdGenerateSize.Name = "cmdGenerateSize";
            this.cmdGenerateSize.Size = new System.Drawing.Size(75, 20);
            this.cmdGenerateSize.TabIndex = 3;
            this.cmdGenerateSize.Text = "Generate";
            this.cmdGenerateSize.UseVisualStyleBackColor = true;
            this.cmdGenerateSize.Click += new System.EventHandler(this.cmdGenerateSize_Click);
            // 
            // cmdSolve
            // 
            this.cmdSolve.Location = new System.Drawing.Point(419, 8);
            this.cmdSolve.Name = "cmdSolve";
            this.cmdSolve.Size = new System.Drawing.Size(75, 23);
            this.cmdSolve.TabIndex = 4;
            this.cmdSolve.Text = "Solve";
            this.cmdSolve.UseVisualStyleBackColor = true;
            this.cmdSolve.Click += new System.EventHandler(this.cmdSolve_Click);
            // 
            // rbBFS
            // 
            this.rbBFS.AutoSize = true;
            this.rbBFS.Location = new System.Drawing.Point(300, 11);
            this.rbBFS.Name = "rbBFS";
            this.rbBFS.Size = new System.Drawing.Size(45, 17);
            this.rbBFS.TabIndex = 5;
            this.rbBFS.TabStop = true;
            this.rbBFS.Text = "BFS";
            this.rbBFS.UseVisualStyleBackColor = true;
            // 
            // rbGBFS
            // 
            this.rbGBFS.AutoSize = true;
            this.rbGBFS.Location = new System.Drawing.Point(351, 11);
            this.rbGBFS.Name = "rbGBFS";
            this.rbGBFS.Size = new System.Drawing.Size(53, 17);
            this.rbGBFS.TabIndex = 6;
            this.rbGBFS.TabStop = true;
            this.rbGBFS.Text = "GBFS";
            this.rbGBFS.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 352);
            this.Controls.Add(this.rbGBFS);
            this.Controls.Add(this.rbBFS);
            this.Controls.Add(this.cmdSolve);
            this.Controls.Add(this.cmdGenerateSize);
            this.Controls.Add(this.dgvSudokuTable);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.lblSize);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSudokuTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.DataGridView dgvSudokuTable;
        private System.Windows.Forms.Button cmdGenerateSize;
        private System.Windows.Forms.Button cmdSolve;
        private System.Windows.Forms.RadioButton rbBFS;
        private System.Windows.Forms.RadioButton rbGBFS;
    }
}

