using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudoku_grid
{
    public partial class NumericEntryForm : Form
    {
        public NumericEntryForm()
        {
            InitializeComponent();
            buttonOK.Click += (sender, e) => DialogResult = DialogResult.OK;
            buttonCancel.Click += (sender, e) => DialogResult = DialogResult.Cancel;
            Load += (sender, e) => BeginInvoke(() => numericUpDown.Select(0, 1));
        }

        public DialogResult ShowDialog(IWin32Window owner, int? value)
        {
            numericUpDown.Value = value ?? 0;
            return base.ShowDialog(owner);
        }
        public int? Value => 
            numericUpDown.Value == 0 ? 
            null : 
            (int)numericUpDown.Value;
    }
}
