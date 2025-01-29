 You're reporting an error:

`IDE0059 Unnecessary assignment of a value to myRow1List`

If I'm understanding the code that you _did_ post, it seems likely to create way more than the 81 textboxes you need and this will make for overlaps and conflicting assignments. To solve, make _only_ the 81 display controls and work with collections that contain _references to_ those controls, _not_ the controls themselves. Here's what I mean.

___
#### Game Board

Idiomatically, a "game board UI" is often represented in WinForms as a `TableLayoutPanel`. Using inheritance, a control like `Label` can be used as the basis for a `Square`. Making an `indexer` for `MainForm` allows squares to be easily referenced by their coordinates.

##### Indexer

_Allows statements like `this[column, row] = square;`_

~~~
Square this[int column, int row]
{
    get => gameBoard.GetControlFromPosition(column, row) as Square 
           ?? throw new InvalidOperationException();
    set => gameBoard.Controls.Add(value, column, row);
}
~~~
___

The uninitialized game board can be populated by iterating its rows and columns 
~~~
public MainForm()
{
    InitializeComponent();
    for (int column = 0; column < 9; column++)
    {
        for (int row = 0; row < 9; row++)
        {
            // Square inherits from Label
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
}
~~~

###### Game Board, after running `InitGame` and player makes a few moves.

[![game board][1]][1]

___

**Columns, Rows, and Nonants**


Now you're set up to where instead of the `RowList`, `ColumnList` and `BlockList` you simply leverage the indexer to make the collections that you need.

~~~

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
~~~


  [1]: https://i.sstatic.net/nS4k90rP.png