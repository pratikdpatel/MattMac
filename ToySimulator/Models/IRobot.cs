using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Models
{
    public interface IRobot
    { 
        IPosition CurrentPosition { get; set; }
        public bool Place(IPosition newPosition);
        public bool Move();
        public bool Left();
        public bool Right();
        public bool Report();
    }
}
