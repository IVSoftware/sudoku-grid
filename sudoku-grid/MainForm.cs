using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography.Xml;

namespace sudoku_grid
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            for (int column = 0; column < 9; column++)
            {
                for (int row = 0; row < 9; row++)
                {
                    var square = new Square
                    {
                        Size = new Size(48, 48),
                        Margin = new Padding(1),
                        Anchor = (AnchorStyles)0xf,
                        BackColor = Color.DarkGray,
                        ForeColor = Color.WhiteSmoke,
                        BorderStyle = BorderStyle.FixedSingle,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font(Font.FontFamily, 16),
                    };
                    square.Click += Any_SquareClicked;
                    this[column, row] = square;
                }
            }
            InitGame();
#if DEBUG
            DoSelfTest();
#endif
        }

        private void DoSelfTest()
        {
            // Output rows to debug window
            for(int row = 0; row < 9; row++)
            {
                Debug.WriteLine(string.Join(",", GetRow(row).Select(_=>_.Value ?? 0)));
            }

            // Output nonants 1-9 to debug window
            for (int oneOfNine = 0; oneOfNine < 9; oneOfNine++)
            {
                var nonant = GetNonant(oneOfNine);

                for (int row = 0; row < 3; row++)
                {
                    Debug.WriteLine(string.Join(",", Enumerable.Range(0, 3)
                        .Select(column => nonant[row, column].Value ?? 0)));
                }
                Debug.WriteLine("");
            }
        }

        Square this[int column, int row]
        {
            get => gameBoard.GetControlFromPosition(column, row) as Square ?? throw new InvalidOperationException();
            set => gameBoard.Controls.Add(value, column, row);
        }

        private void Any_SquareClicked(object? sender, EventArgs e)
        {
            if (sender is Square square && !square.IsFixedValue)
            {

                using(var entry = new NumericEntryForm())
                {
                    if(DialogResult.Cancel != entry.ShowDialog(this, square.Value))
                    {
                        square.Value = entry.Value;
                    }
                }
            }
        }

        Square[] GetRow(int row) =>
            Enumerable
            .Range(0, 9)
            .Select(_ => this[_, row])
            .ToArray();

        Square[] GetColumn(int column) =>
            Enumerable
            .Range(0, 9)
            .Select(_ => this[column, _])
            .ToArray();
        Square[,] GetNonant(int oneOfNine)
        {
            int startRow = (oneOfNine / 3) * 3;
            int startColumn = (oneOfNine % 3) * 3;
            Square[,] nonant = new Square[3, 3];
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    nonant[row, column] = this[startColumn + column, startRow + row];
                }
            }
            return nonant;
        }

        void InitGame()
        {
            this[4, 0].FixedValue = 8;

            this[1, 1].FixedValue = 2;
            this[3, 1].FixedValue = 7;
            this[4, 1].FixedValue = 1;
            this[8, 1].FixedValue = 5;

            this[0, 2].FixedValue = 8;
            this[5, 2].FixedValue = 5;
            this[8, 2].FixedValue = 1;

            this[0, 3].FixedValue = 7;
            this[2, 3].FixedValue = 9;
            this[5, 3].FixedValue = 3;
            this[6, 3].FixedValue = 4;

            this[1, 4].FixedValue = 4;
            this[3, 4].FixedValue = 5;
            this[8, 4].FixedValue = 3;

            this[2, 5].FixedValue = 5;
            this[7, 5].FixedValue = 7;
            this[8, 5].FixedValue = 9;

            this[0, 6].FixedValue = 5;
            this[4, 6].FixedValue = 7;
            this[7, 6].FixedValue = 9;
            this[8, 6].FixedValue = 2;

            this[2, 7].FixedValue = 6;
            this[3, 7].FixedValue = 3;

            this[1, 8].FixedValue = 9;
            this[2, 8].FixedValue = 2;
            this[3, 8].FixedValue = 4;
            this[6, 8].FixedValue = 7;
        }



        class Square : Label
        {
            public new string Text
            {
                get => base.Text;
                set { }
            }
            public int? Value
            {
                get => _value;
                set
                {
                    if (!Equals(_value, value))
                    {
                        _value = value;
                        base.Text = $"{value}";
                    }
                }
            }
            int? _value = default;

            public bool IsFixedValue { get; private set; }
            public int? FixedValue
            {
                set
                {
                    Value = value;
                    IsFixedValue = value is not null;
                    BackColor = 
                        IsFixedValue
                        ? Color.FromArgb(0x22, 0x22,0x22)
                        : Color.DarkGray;
                }
            }
        }
    }
}
