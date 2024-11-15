using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._2C
{
    public class Paths : GameObject
    {
        public Location Destination { get; set; }

        public Paths(string[] ids, string name, string description, Location destination) : base(ids, name, description)
        {
            Destination = destination;
        }

        public void MovePlayer(Player player)
        {
            player.Location = Destination;
        }
    }
}