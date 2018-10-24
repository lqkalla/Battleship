using System;
using System.Collections.Generic;
using Domain;

namespace Initializers
{
    public static class BoardInit
    {
        public static Board NewBoard()
        {
            Board board = new Board(Settings.Rows, Settings.Columns);
            
            List<Ship> ships = new List<Ship>();
            ships.Add(new Ship(1, 1));
            ships.Add(new Ship(1, 2));
            ships.Add(new Ship(1, 3));
            ships.Add(new Ship(1, 4));
            ships.Add(new Ship(1, 5));
            board.Ships = ships;

            return board;
        }
    }
}