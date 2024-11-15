using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._1C
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] {"move", "head", "go", "leave"})
        { }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 2)
            {
                return "I don't know how to move like that!";
            }

            if (!(new string[] { "move", "go", "head", "leave" }).Contains(text.ElementAt(0))) //If not those words, ask again
            {
                return "Where would you like to move?";
            }

            string direction = text[1];

            Paths path = p.Location.GetPath(direction);
            if (path == null)
            {
                return $"There is no path to the {direction}.";
            }
            path.MovePlayer(p);
            return $"You move {direction} to {p.Location.Name}.";

        }
    }
}
