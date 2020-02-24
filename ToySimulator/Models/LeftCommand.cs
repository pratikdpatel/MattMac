using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Models
{
    public class LeftCommand : RobotCommand
    {
        public LeftCommand(IRobot robot) : base (robot) { }
        public override void Execute()
        {
           IsSuccessful = Robot.Left();
        }
    }
}
