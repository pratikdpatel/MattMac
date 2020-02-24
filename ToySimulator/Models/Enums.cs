using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Models
{
    public enum Facing
    {
        NOTSET = 0,
        NORTH = 1,
        EAST = 2,
        SOUTH = 3,
        WEST = 4
    }
    public enum CommandExecutionResult
    {
        ABORT = 0,
        CONTINUE
    }
}
