using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Models
{
    public class Simulator
    {
        public Queue<RobotCommand> Commands;
        public Position CurrentPosition;
        
        public Simulator()
        {
            Commands = new Queue<RobotCommand>();            
        }

        public void ExecuteCommands()
        {
            Console.WriteLine("Executing Commands:");
            var placeCommandExecuted = false;
            while(Commands.Count > 0)
            {
                RobotCommand command = Commands.Dequeue();
                if (command is PlaceCommand)
                {
                    command.Execute();
                    if (command.IsSuccessful)
                    {
                        placeCommandExecuted = true;
                    }
                }
                else
                {
                    if (placeCommandExecuted)
                    {
                        command.Execute();
                    }
                }
            }
            if (!placeCommandExecuted)
            {
                Console.WriteLine("Command Set failed to execute as no Place command found or executed successfully");
            }
        }
    }
}   
