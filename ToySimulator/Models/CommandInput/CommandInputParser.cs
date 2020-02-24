using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Models.CommandInput
{
    public class CommandInputParser
    {
        public List<RobotCommand> CommandList;
        public List<CommandInputBase> PlaceCommandInputs;
        public Position PlacePosition;
        public Robot Robot;
        public CommandInputParser()
        {
            CommandList = new List<RobotCommand>();
            PlaceCommandInputs = new List<CommandInputBase>();
            Robot = new Robot();            
        }
        public void Parse(string commandInstruction)
        {
            if (commandInstruction.ToLower().StartsWith("place") && commandInstruction.Contains(','))
            {
                PlacePosition = new Position();
                PlaceCommandEvaluation(new List<string>(commandInstruction.Split(',')));
                if (PlaceCommandInputs.Count > 0)
                {                    
                    foreach(var item in PlaceCommandInputs)
                    {
                        var output = item.Evaluate();
                        switch(output) {
                            case Tuple<string, int> tuple:
                                PlacePosition.X = tuple.Item2; 
                                break;
                            case int y:
                                PlacePosition.Y = y;
                                break;
                            case Facing facing:
                                PlacePosition.Facing = facing;
                                break;
                            default:
                                break;
                        }
                    }                    
                    CommandList.Add(new PlaceCommand(Robot) { NewPosition = PlacePosition});
                }
            }
            else
            {
                OtherCommandEvaluation(commandInstruction);
            }            
        }

        public void PlaceCommandEvaluation(List<string> commandInstructions)
        {
            if (commandInstructions[0].ToLower().StartsWith("place") && commandInstructions[0].Contains(' '))
            {
                var commandPart = commandInstructions[0];
                commandInstructions.RemoveAt(0);
                                
                PlaceCommandInput placeCommandInput = new PlaceCommandInput(commandPart);
                PlaceCommandInputs.Add(placeCommandInput);                
            }
            else if(int.TryParse(commandInstructions[0], out _))
            {
                var commandPart = commandInstructions[0];
                commandInstructions.RemoveAt(0);
                IntegerCommanInput integerCommanInput = new IntegerCommanInput(commandPart);
                PlaceCommandInputs.Add(integerCommanInput);
            }
            else if(Enum.TryParse<Facing>(commandInstructions[0], out _))
            {
                var commandPart = commandInstructions[0];
                commandInstructions.RemoveAt(0);
                FacingCommandInput facingCommandInput = new FacingCommandInput(commandPart);
                PlaceCommandInputs.Add(facingCommandInput);
            }
            if (commandInstructions.Count > 0) {
                PlaceCommandEvaluation(commandInstructions);
            }            
        }

        public void OtherCommandEvaluation(string commandInstruction)
        {
            switch (commandInstruction.ToLower())
            {
                case "move":
                    CommandList.Add(new MoveCommand(Robot));
                    break;
                case "left":
                    CommandList.Add(new LeftCommand(Robot));
                    break;
                case "right":
                    CommandList.Add(new RightCommand(Robot));
                    break;
                case "report":
                    CommandList.Add(new ReportCommand(Robot));
                    break;
                default:
                    //ignore
                    break;
            }
        }
    }
}
