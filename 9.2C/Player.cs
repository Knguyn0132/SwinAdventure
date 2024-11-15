using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._2C
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private Location _location;

        public Player(string name, string description) : base(new string[] { "me", "inventory" }, name, description) { } //name and des gotten from GameObject
        //help the class identify itself and its item, 3 batteries, 2 from GO and 1 from IO
        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this; //return then player object itself
            }
            GameObject item = _inventory.Fetch(id); // Fetch the item from the inventory if it exists.
            if (item != null)
            {
                return item; // Return the item if found in the inventory.
            }
            //Check for location if not found in inventory
            if (_location != null)
            {
                return _location.Locate(id); //instead of returning null like the first time, this time it will look for the location
            }
            return null;
        }

        public override string FullDescription
        {
            get
            {
                return $"You are {Name}, {base.FullDescription}\nYou are carrying:\n{_inventory.ItemList}";
            }
        }

        public Inventory Inventory { get { return _inventory; } }

        public Location Location 
            { 
                get { return _location; }
                set { _location = value; }
            }

        public string Move(string direction)
        {
            MoveCommand moveCommand = new MoveCommand();
            return moveCommand.Execute(this, new string[] { "move", direction });
                                      //instance of player
        }


    }
}
