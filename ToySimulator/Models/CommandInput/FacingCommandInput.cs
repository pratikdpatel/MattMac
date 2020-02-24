using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Models.CommandInput
{
    public class FacingCommandInput : CommandInputBase
    {
        Facing Facing;
        public FacingCommandInput(string facing)
        {
            if(Facing.TryParse(facing, out Facing facingItem))
            {
                Facing = facingItem;
            }
        }
        public override object Evaluate()
        {
            return Facing;
        }
    }
}
