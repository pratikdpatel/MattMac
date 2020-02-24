using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Models
{
    public class Robot : IRobot
    {
        public IPosition CurrentPosition { get; set; }
        public Robot()
        {
            CurrentPosition = new Position();
        }        

        public bool Place(IPosition newPosition)
        {

            if (newPosition.X < 0 || newPosition.X > 5 || newPosition.Y < 0 || newPosition.Y > 5 || newPosition.Facing == Facing.NOTSET)
            {
                Console.WriteLine("Invalid position. Place command won't be implemented");
                return false;
            }

            CurrentPosition.X = newPosition.X;
            CurrentPosition.Y = newPosition.Y;
            CurrentPosition.Facing = newPosition.Facing;
            return true;
        }

        public bool Move()
        {
            switch (CurrentPosition.Facing)
            {
                case Facing.NORTH:
                    if (CurrentPosition.Y == 5)
                    {
                        Console.WriteLine("Caution! Cannot move forward");                        
                        return false;
                    }
                    CurrentPosition.Y += 1;
                    break;
                case Facing.EAST:
                    if (CurrentPosition.X == 5)
                    {
                        Console.WriteLine("Caution! Cannot move forward");
                        return false;
                    }
                    CurrentPosition.X += 1;
                    break;
                case Facing.SOUTH:
                    if (CurrentPosition.Y == 0)
                    {
                        Console.WriteLine("Caution! Cannot move forward");
                        return false;
                    }
                    CurrentPosition.Y -= 1;
                    break;
                case Facing.WEST:
                    if (CurrentPosition.X == 0)
                    {
                        Console.WriteLine("Caution! Cannot move forward");
                        return false;
                    }
                    CurrentPosition.X -= 1;
                    break;
                default:
                    Console.WriteLine("Invalid Facing Direction.");
                    return false;
            }
            return true;
        }

        public bool Left()
        {            
            if (CurrentPosition.Facing == 0) return false;

            if ((int)CurrentPosition.Facing == 1)
            {
                CurrentPosition.Facing = Facing.WEST;
            }
            else
            {
                CurrentPosition.Facing -= 1;
            }
            return true;
        }

        public bool Right()
        {
            if (CurrentPosition.Facing == 0) return false;

            if ((int)CurrentPosition.Facing == 4)
            {
                CurrentPosition.Facing = Facing.NORTH;
            }
            else
            {
                CurrentPosition.Facing += 1;
            }
            return true;
        }

        public bool Report()
        {
            Console.WriteLine($"Output: {CurrentPosition.X}, {CurrentPosition.Y}, {CurrentPosition.Facing}");
            return true;
        }
        
    }
}
