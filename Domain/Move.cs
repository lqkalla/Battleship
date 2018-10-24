using System;
using System.Collections.Generic;

namespace Domain
{
    public class Move
    {
        public static List<Move> AllTheMovesInGame = new List<Move>();

        public BoardSquare square;

        public Coordinates Coordinates;

        public BoardSquareState BoardSquareState;

        public Move(Board board)
        {
            AllTheMovesInGame.Add(this);
            Console.WriteLine(board);
            Console.WriteLine("Choose coordinates where to attack.");
            Coordinates = new Coordinates(Console.ReadLine().Trim().ToUpper());
            Attack(board);
        }

        private void Attack(Board board)
        {
            square = board.GetBoardSquareByCoordinates(Coordinates);

            if (square.BoardSquareState == BoardSquareState.Empty)
            {
                square.BoardSquareState = BoardSquareState.Miss;
            }
            else if (square.BoardSquareState == BoardSquareState.Player)
            {
                square.BoardSquareState = BoardSquareState.Hit;

            }
        }
    }
}