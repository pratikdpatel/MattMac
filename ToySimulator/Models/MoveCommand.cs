using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Models
{
    public class MoveCommand : RobotCommand
    {
        public MoveCommand(IRobot robot) : base(robot) { }
        public override void Execute()
        {
            IsSuccessful = Robot.Move();
        }
    }
}
