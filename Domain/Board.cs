using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Domain
{
    public class Board
    {
        private List<List<BoardSquare>> board { get; set; }
        private int row;
        private int col;
        public List<Ship> Ships { get; set; } = new List<Ship>();        


        public Board(int rows, int cols)
        {
            row = rows;
            col = cols;
            
            board = new List<List<BoardSquare>>();
            List<BoardSquare> rowOfBoardSquares;
            
            for (int i = 0; i < row; i++)
            {
                rowOfBoardSquares = new List<BoardSquare>();
                
                for (int j = 0; j < col; j++)
                {
                    rowOfBoardSquares.Add(new BoardSquare(j, i + 1));
                }

                board.Add(rowOfBoardSquares);
            }
        }

        public void AddShip(Ship ship, Coordinates coordinates)
        {
            ship.setBeginningCoordinates(coordinates);
            
            foreach (Coordinates c in ship.ListOfCoordinates)
            {
                BoardSquare square = GetBoardSquareByCoordinates(c);
                square.BoardSquareState = BoardSquareState.Player;
                ship.ShipBoardSquares.Add(square);
            }

        }


        public BoardSquare GetBoardSquareByCoordinates(Coordinates coordinates)
        {
            foreach (var row in board)
            {
                foreach (var boardSquare in row)
                {
                    if (boardSquare.Coordinates.Equals(coordinates))
                    {
                        return boardSquare;
                    }
                }
            }

            Console.WriteLine("No boardsquare found with such coordinates.");
            return null;
        }
        
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("      ");
            int countAlphabet = 65;
            for (int i = 0; i < col; i++)
            {
                stringBuilder.Append(Char.ConvertFromUtf32(countAlphabet));
                stringBuilder.Append("    ");
                countAlphabet++;
            }

            stringBuilder.Append("\n");
            stringBuilder.Append(GetSeparatorLine());
            stringBuilder.Append("\n");

            int count = 1;
            for (int i = 0; i < row; i++)
            {
                if (i < 9)
                {
                    stringBuilder.Append("0");
                }
                stringBuilder.Append(count);
                count++;
                stringBuilder.Append(" ");

                stringBuilder.Append(GetLine(i));
                stringBuilder.Append("\n");
                stringBuilder.Append(GetSeparatorLine());
                stringBuilder.Append("\n");
            }
            

            return stringBuilder.ToString();
        }

        private string GetSeparatorLine()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("   ");
            sb.Insert(sb.Length, "-----", col);
            sb.Append("-");
            return sb.ToString();
        }

        private string GetLine(int row)
        {
            StringBuilder sBuilder = new StringBuilder();

            sBuilder.Append("|");
            foreach (var square in board.ElementAt(row))
            {
                sBuilder.Append(" ");
                sBuilder.Append(square);
                sBuilder.Append("  ");
                sBuilder.Append("|");
            }

            return sBuilder.ToString();
        }
        
        public void ChooseShipLocations()
        {
            String inputCoordinates;
            String[] inputCords = { "01A", "02B", "09C", "10A", "04D"};

            int count = 0;
            foreach (var ship in Ships)
            {
                do 
                {
                    Console.Clear();
                    
                    Console.WriteLine(this);

                    Console.WriteLine("Choose the beginning coordinate of your " + ship + " ship.");
                    Console.WriteLine("To switch between ship orientation, press enter.");
                    Console.WriteLine("Enter your choice: ");

                    //inputCoordinates = Console.ReadLine().Trim().ToUpper();
                    inputCoordinates = inputCords[count];

                   
                    if (!inputCoordinates.Equals(""))
                    {
                        break;
                    }
                    ship.SwitchHorizontalVerticalSizes();
                    
                } while (true);
                
                Console.Clear();

                Coordinates input = new Coordinates(inputCoordinates);
                AddShip(ship, input);
                Console.WriteLine("Chosen coordinates: " + inputCoordinates + "\n");
                
                count++;

            }
            Console.Clear();
            Console.WriteLine("Your ship locations");
            Console.WriteLine(this);
            Console.WriteLine("Press anything to start playing: ");
            Console.ReadKey();

        }

        public bool AllShipsSunken()
        {
            foreach (var ship in Ships)
            {
                if (!ship.IsSunken())
                {
                    return false;
                }
            }

            return true;
        }

        public void chooseShipLocationsRandom()
        {
            Random random = new Random();
            string column;
            string row;
            int r;
            foreach (var ship in Ships)
            {
                row = "";
                column = Char.ConvertFromUtf32(random.Next(65, 64 + Settings.Columns));
                r = random.Next(1, Settings.Rows);
                if (r < 10)
                {
                    row += "0";
                }
                row += r.ToString();
                
                Coordinates input = new Coordinates(row + column);
                AddShip(ship, input);
            }
        }
       
    }
}