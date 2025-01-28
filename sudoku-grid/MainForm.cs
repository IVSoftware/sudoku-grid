using System.Data.Common;
using System.Drawing;
using System.Security.Cryptography.Xml;

namespace sudoku_grid
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            for (int col = 0; col < 9; col++)
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
                    gameBoard.Controls.Add(square, col, row);
                }
            }
            InitGame();
        }

        private void Any_SquareClicked(object? sender, EventArgs e)
        {
            if (sender is Square square && !square.IsFixedValue)
            {

            }
        }

        Square GetSquare(int col, int row) =>
            gameBoard
            .GetControlFromPosition(col, row) as Square 
            ?? throw new NullReferenceException();

        void InitGame()
        {
            GetSquare(4, 0).FixedValue = 8;

            GetSquare(1, 1).FixedValue = 2;
            GetSquare(3, 1).FixedValue = 7;
            GetSquare(4, 1).FixedValue = 1;
            GetSquare(8, 1).FixedValue = 5;

            GetSquare(0, 2).FixedValue = 8;
            GetSquare(5, 2).FixedValue = 5;
            GetSquare(8, 2).FixedValue = 1;

            GetSquare(0, 3).FixedValue = 7;
            GetSquare(2, 3).FixedValue = 9;
            GetSquare(5, 3).FixedValue = 3;
            GetSquare(6, 3).FixedValue = 4;

            GetSquare(1, 4).FixedValue = 4;
            GetSquare(3, 4).FixedValue = 5;
            GetSquare(8, 4).FixedValue = 3;

            GetSquare(2, 5).FixedValue = 5;
            GetSquare(7, 5).FixedValue = 7;
            GetSquare(8, 5).FixedValue = 9;

            GetSquare(0, 6).FixedValue = 5;
            GetSquare(4, 6).FixedValue = 7;
            GetSquare(7, 6).FixedValue = 9;
            GetSquare(8, 6).FixedValue = 2;

            GetSquare(2, 7).FixedValue = 6;
            GetSquare(3, 7).FixedValue = 3;

            GetSquare(1, 8).FixedValue = 9;
            GetSquare(2, 8).FixedValue = 2;
            GetSquare(3, 8).FixedValue = 4;
            GetSquare(6, 8).FixedValue = 7;
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
