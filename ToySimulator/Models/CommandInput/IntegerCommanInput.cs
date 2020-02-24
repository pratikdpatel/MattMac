using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Models.CommandInput
{
    public class IntegerCommanInput : CommandInputBase
    {
        int Ycoordinate { get; set; }
        public IntegerCommanInput(string yCoordinate)
        {
            if(int.TryParse(yCoordinate, out int y))
            {
                Ycoordinate = y;
            }
        }
        public override object Evaluate()
        {
            return Ycoordinate;
        }
    }
}
