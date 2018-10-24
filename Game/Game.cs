using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Initializers;

namespace Game
{
    class Game
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("---------- Battleship ----------");


            Console.WriteLine("How many rows? rows > 5");
            //int rows = Convert.ToInt32(Console.ReadLine());
  
            Console.WriteLine("How many columns? cols > 5");
            //int columns = Convert.ToInt32(Console.ReadLine());

            int rows = Settings.Rows;
            int columns = Settings.Columns;

            Board playerDefenseBoard = BoardInit.NewBoard();
            playerDefenseBoard.ChooseShipLocations();

            Board playerAttackBoard = BoardInit.NewBoard();
            playerAttackBoard.chooseShipLocationsRandom();
            //choosing of computer's ships
            Play(playerAttackBoard);




        }

        public static void Play(Board board)
        {
            Move move;

            do
            {
                Console.Clear();
                move = new Move(board);
                Console.WriteLine(board);


            } while (!board.AllShipsSunken());

            Console.WriteLine("Congrats, game is over.");
        }


    }
}