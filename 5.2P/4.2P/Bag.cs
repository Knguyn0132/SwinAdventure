using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._2P
{
    public class Bag : Item
    {
        private Inventory _inventory;

        public Bag(string[] ids, string name, string description) : base(ids, name, description) 
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }

        public string FullDescription
        {
            get
            {
                return $"In the {Name} you can see: {string.Join(", ", _inventory.ItemList)}"; //add "," between every elements
            }           
        }

        public Inventory Inventory
            { get { return _inventory; } }

    }
}
