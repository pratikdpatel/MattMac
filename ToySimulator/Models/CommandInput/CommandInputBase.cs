using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Models.CommandInput
{
    public abstract class CommandInputBase
    {
        public abstract object Evaluate();
    }
}
