using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2P
{
    public class Player : GameObject
    {
        private Inventory _inventory =  new Inventory();

        public Player(string name, string description) : base (new string[] { "me", "inventory" }, name, description) { } //name and des gotten from GameObject
        //help the class identify itself and its item, 3 batteries, 2 from GO and 1 from IO
        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this; //return then player object itself
            }
            return _inventory.Fetch(id);
            //searches the inventory for an item with the given identifier and returns it if found. If no item matches, it returns null.
        }

        public override string FullDescription
        {
            get
            {
                return $"You are {Name}, {base.FullDescription}\nYou are carrying:\n{_inventory.ItemList}";
            }
        }

        public Inventory Inventory { get { return _inventory; } }
    }
}
