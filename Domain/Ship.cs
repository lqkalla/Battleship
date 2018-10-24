using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;

namespace Domain
{
    public class Ship
    {
        public Coordinates BeginningCoordinates { get; set; }
        public int Size = 0;
        public bool orientationHorizontal = true;
        public int row_length { get; set; }
        public int col_length { get; set; }
        public List<Coordinates> ListOfCoordinates { get; set; } = new List<Coordinates>();
        public List<BoardSquare> ShipBoardSquares = new List<BoardSquare>();

        public Ship(int rowLength, int colLength)
        {
            col_length = colLength;
            row_length = rowLength;
            orientationHorizontal = IsHorizontal();
        }

        public Ship(int rowLength, int colLength, Coordinates beginningCoordinates)
        {
            col_length = colLength;
            row_length = rowLength;
            orientationHorizontal = IsHorizontal();

            BeginningCoordinates = beginningCoordinates;

            ListOfCoordinates = new List<Coordinates>();
            CalculateListOfShipCoordinates();
        }

        public void setBeginningCoordinates(Coordinates beginningCoordinates)
        {
            BeginningCoordinates = beginningCoordinates;
            CalculateListOfShipCoordinates();
        }

        public bool IsSunken()
        {
            foreach (var square in ShipBoardSquares)
            {
                if (square.BoardSquareState == BoardSquareState.Player)
                {
                    return false;
                }
            }
            
            return true;
        }
        
        private bool IsHorizontal()
        {
            if (row_length == 1)
            {
                Size = col_length;
                return true;
            }

            Size = row_length;
            return false;
        }

        public List<Coordinates> CalculateListOfShipCoordinates()
        {
            Coordinates nextCoordinates;

            int size = row_length;

            if (IsHorizontal())
            {
                size = col_length;
            }


            ListOfCoordinates = new List<Coordinates>();
            ListOfCoordinates.Add(BeginningCoordinates);

            if (Size == 1)
            {
                return ListOfCoordinates;
            }

            for (int i = 0; i < size; i++)
            {
                if (IsHorizontal())
                {
                    nextCoordinates = BeginningCoordinates.GetHorizontallyNextCoordinates();
                }
                else
                {
                    nextCoordinates = BeginningCoordinates.GetVerticallyNextCoordinates();
                }

                ListOfCoordinates.Add(nextCoordinates);
            }


            return ListOfCoordinates;
        }

        public override string ToString()
        {
            return col_length + " x " + row_length;
        }

        public void SwitchHorizontalVerticalSizes()
        {
            int temp = col_length;
            col_length = row_length;
            row_length = temp;
            orientationHorizontal = !orientationHorizontal;
        }
    }
}