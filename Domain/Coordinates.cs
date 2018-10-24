using System;
using System.Text;
using System.Threading;
using System.Xml;

namespace Domain
{
    public class Coordinates
    {
        private string Column { get; set; }
        private string Row { get; set; }
        private int ColumnInt { get; set; }
        private int RowInt { get; set; }

        public Coordinates(string coordinates)
        {
            Row = coordinates.Substring(0, 2);
            Column = coordinates.Substring(2);
            
            FindIntCordinates();
        }
        
        
        public Coordinates(int column, int row)
        {
            ColumnInt = column;
            RowInt = row;

            Tuple<string, string> tuple = findStringRepresentationFromIntCoordinates(column, row);
            Row = tuple.Item2;
            Column = tuple.Item1;

           FindIntCordinates();

        }

        public static Tuple<string, string> findStringRepresentationFromIntCoordinates(int col, int row)
        {
            StringBuilder colStringBuilder = new StringBuilder();
            StringBuilder rowStringBuilder = new StringBuilder();
            
            if (row < 10)
            {
                rowStringBuilder.Append("0");
            }

            rowStringBuilder.Append(row);
            
            int counter = 0;
            for (int i = 65; i < 91; i++)
            {
                if (counter == col)
                {
                    colStringBuilder.Append(Char.ConvertFromUtf32(i));
                    break;
                }

                counter++;
            }

            return Tuple.Create(colStringBuilder.ToString(), rowStringBuilder.ToString());
        }

        private void FindIntCordinates()
        {
            RowInt = Convert.ToInt32(Row);

            int count = 0;
            for (int i = 65; i < 91; i++)
            {
                if (Column == Char.ConvertFromUtf32(i))
                {
                    ColumnInt = count;
                    break;
                }
                
                count++;
            }

        }

        public Coordinates GetHorizontallyNextCoordinates()
        {
            return new Coordinates(ColumnInt++, RowInt);
        }
        
        public Coordinates GetVerticallyNextCoordinates()
        {
            return new Coordinates(ColumnInt, RowInt++);
        }

        public override bool Equals(object obj)
        {
            Coordinates c = (Coordinates) obj;
            if ((Row+Column).Equals(c.Row+c.Column))
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return Row + Column;
        }
    }
}