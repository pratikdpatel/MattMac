using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Models
{
    public class ReportCommand : RobotCommand
    {
        public ReportCommand(IRobot robot) : base(robot) { }
        public override void Execute()
        {
            IsSuccessful = Robot.Report();
        }
    }
}
