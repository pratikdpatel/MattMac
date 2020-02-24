using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Models
{
    public class RightCommand : RobotCommand
    {
        public RightCommand(IRobot robot) : base(robot) { }
        public override void Execute()
        {
            IsSuccessful = Robot.Right();    
        }
    }
}
