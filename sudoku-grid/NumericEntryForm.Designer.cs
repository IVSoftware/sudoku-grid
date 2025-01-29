namespace sudoku_grid
{
    partial class NumericEntryForm
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
            numericUpDown = new NumericUpDown();
            buttonOK = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            SuspendLayout();
            // 
            // numericUpDown
            // 
            numericUpDown.Location = new Point(23, 29);
            numericUpDown.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(134, 50);
            numericUpDown.TabIndex = 0;
            numericUpDown.TextAlign = HorizontalAlignment.Center;
            // 
            // buttonOK
            // 
            buttonOK.Font = new Font("Segoe UI", 10F);
            buttonOK.Location = new Point(23, 116);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(134, 45);
            buttonOK.TabIndex = 1;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Segoe UI", 10F);
            buttonCancel.Location = new Point(173, 116);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(134, 45);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // NumericEntryForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(18F, 45F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(342, 177);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(numericUpDown);
            Font = new Font("Segoe UI", 16F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(5);
            Name = "NumericEntryForm";
            Padding = new Padding(40);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Numeric Entry Form";
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private NumericUpDown numericUpDown;
        private Button buttonOK;
        private Button buttonCancel;
    }
}