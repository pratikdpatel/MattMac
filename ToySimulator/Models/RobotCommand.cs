using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Models
{
    public abstract class RobotCommand
    {
        protected IRobot Robot;
        public bool IsSuccessful;
        public RobotCommand(IRobot robot)
        {
            Robot = robot;
        }

        public abstract void Execute();
    }
}
