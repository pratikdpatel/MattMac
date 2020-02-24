using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Models.CommandInput
{
    public class PlaceCommandInput : CommandInputBase
    {
        string Input;
        public PlaceCommandInput(string input)
        {
            Input = input;
        }
        public override object Evaluate()
        {
            var items = Input.Split(' ');

            if (items.Length == 2 && items[0].ToLower() == "place" && int.TryParse(items[1], out int x))
            {
                return Tuple.Create(items[0], x);
            }
            return null;
        }
    }
}
