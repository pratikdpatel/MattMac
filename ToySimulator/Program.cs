using System;
using ToySimulator.Models;
using ToySimulator.Models.CommandInput;

namespace ToySimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-: TOY SIMULATION :-");
            //BasicRobotCommandExecution();
            ExecuteListOfCommands();
        }

        public static void BasicRobotCommandExecution()
        {
            var robot = new Robot();
            var simulator = new Simulator();

            var invalidMoveCommand = new MoveCommand(robot);
            simulator.Commands.Enqueue(invalidMoveCommand);

            var invalidLeftCommand = new LeftCommand(robot);
            simulator.Commands.Enqueue(invalidLeftCommand);

            var placeCommand = new PlaceCommand(robot)
            {
                NewPosition = new Position() { X = 0, Y = 2, Facing = Facing.WEST }
            };
            simulator.Commands.Enqueue(placeCommand);

            var moveCommand = new MoveCommand(robot);
            simulator.Commands.Enqueue(moveCommand);

            var rightCommand = new RightCommand(robot);
            simulator.Commands.Enqueue(rightCommand);

            //var moveCommand2 = new MoveCommand(robot);
            //simulator.Commands.Enqueue(moveCommand2);

            //var moveCommand3 = new MoveCommand(robot);
            //simulator.Commands.Enqueue(moveCommand3);

            //simulator.Commands.Enqueue(rightCommand);

            var reportCommand = new ReportCommand(robot);
            simulator.Commands.Enqueue(reportCommand);

            simulator.ExecuteCommands();
        }

        public static void ExecuteListOfCommands()
        {
            string[] commands = new string[]
            {
                "PLACE 0,2,NORTH",
                "MOVE",
                "RIGHT",
                "REPORT"
            };

            string[] commands2 = new string[]
            {
                "MOVE"
                ,"LEFT"
                ,"PLACE 6,2,EAST"
                ,"PLACE 0,0,SOUTH"
                //,"MOVE"
                ,"MOVE"
                //,"LEFT"
                ,"PLACE 3,5,EAST"
                ,"MOVE"
                ,"REPORT"
            };
            var commandInputParser = new CommandInputParser();
            var simulator = new Simulator();
            foreach (var command in commands2)
            {
                commandInputParser.Parse(command);
            }

            foreach(var item in commandInputParser.CommandList)
            {
                simulator.Commands.Enqueue(item);
            }
            simulator.ExecuteCommands();
        }
    }
}
