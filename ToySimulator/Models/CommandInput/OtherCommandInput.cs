using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Models.CommandInput
{
    public class OtherCommandInput : CommandInputBase
    {
        public string CommandName { get; set; }
        public OtherCommandInput(string commandName)
        {
            CommandName = commandName;
        }
        public override object Evaluate()
        {
            return CommandName;
        }
    }
}
