namespace sudoku_grid
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gameBoard = new TableLayoutPanel();
            SuspendLayout();
            // 
            // gameBoard
            // 
            gameBoard.ColumnCount = 10;
            gameBoard.ColumnStyles.Add(new ColumnStyle());
            gameBoard.ColumnStyles.Add(new ColumnStyle());
            gameBoard.ColumnStyles.Add(new ColumnStyle());
            gameBoard.ColumnStyles.Add(new ColumnStyle());
            gameBoard.ColumnStyles.Add(new ColumnStyle());
            gameBoard.ColumnStyles.Add(new ColumnStyle());
            gameBoard.ColumnStyles.Add(new ColumnStyle());
            gameBoard.ColumnStyles.Add(new ColumnStyle());
            gameBoard.ColumnStyles.Add(new ColumnStyle());
            gameBoard.ColumnStyles.Add(new ColumnStyle());
            gameBoard.Location = new Point(27, 28);
            gameBoard.Name = "gameBoard";
            gameBoard.RowCount = 10;
            gameBoard.RowStyles.Add(new RowStyle());
            gameBoard.RowStyles.Add(new RowStyle());
            gameBoard.RowStyles.Add(new RowStyle());
            gameBoard.RowStyles.Add(new RowStyle());
            gameBoard.RowStyles.Add(new RowStyle());
            gameBoard.RowStyles.Add(new RowStyle());
            gameBoard.RowStyles.Add(new RowStyle());
            gameBoard.RowStyles.Add(new RowStyle());
            gameBoard.RowStyles.Add(new RowStyle());
            gameBoard.RowStyles.Add(new RowStyle());
            gameBoard.Size = new Size(452, 452);
            gameBoard.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 511);
            Controls.Add(gameBoard);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sudoku Grid";
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel gameBoard;
    }
}
