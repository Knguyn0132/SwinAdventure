using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._2C
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Paths> _paths;
        public Location(string[] ids, string name, string description) : base(ids, name, description)
        {
            _inventory = new Inventory();
            _paths = new List<Paths>();
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

        public void AddPath(Paths path)
        {
            
                _paths.Add(path);
            
        }

        public Paths GetPath(string direction)
        {
            foreach (Paths path in _paths)
            {
                if (path.AreYou(direction))
                {
                    return path;
                }
            }
            return null;
        }


    }
}
