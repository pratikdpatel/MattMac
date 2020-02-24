using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Models
{
    public interface IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Facing Facing { get; set; }
    }


    /// <summary>
    /// Holds the X, Y axis points and the facing direction
    /// Eligible to be a structure, but create class for testing
    /// </summary>
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Facing Facing { get; set; }
    }
}
