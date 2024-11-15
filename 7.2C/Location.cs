using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2C
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;

        public Location(string[] ids, string name, string description) : base(ids, name, description)
        {
            _inventory = new Inventory();
        }

        public Inventory Inventory
        { get { return _inventory; } }

        public GameObject Locate(string id) //the purpose is to return the gameobject itself
        {
            if (AreYou(id))
                {  return this; }
            return _inventory.Fetch(id);

        }

        public override string FullDescription
        {
            get
            {
                return $"In the {Name} you can see: {string.Join(", ", _inventory.ItemList)}";
            }   
        }
    }
}
