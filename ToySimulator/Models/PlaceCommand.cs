namespace ToySimulator.Models
{
    public class PlaceCommand : RobotCommand
    {
        public Position NewPosition { get; set; }
        public PlaceCommand(IRobot robot) : base(robot) { }

        public override void Execute()
        {
           IsSuccessful = Robot.Place(NewPosition);            
        }
    }
}
