namespace Domain
{
    public class BoardSquare
    {
        public BoardSquareState BoardSquareState { get; set; }
        public Coordinates Coordinates { get; set; }

        public BoardSquare(int col, int row)
        {
            BoardSquareState = BoardSquareState.Empty;
            Coordinates = new Coordinates(col, row);
        }

        public override string ToString()
        {
            if (BoardSquareState == BoardSquareState.Empty)
            {
                return "⚪";
            }
            else if (BoardSquareState == BoardSquareState.Player)
            {
                return "⚫";
            }
            else if (BoardSquareState == BoardSquareState.Hit)
            {
                return "❌";
            }
            else if (BoardSquareState == BoardSquareState.Miss)
            {
                return "⚫";
            }

            return " ";
        }
    }
}