using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1P
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();
        public Inventory() { }
        public bool HasItem(string id)
        {
            return Fetch(id) != null;
        }
        public void Put(Item itm)
        {
            _items.Add(itm);
        }
        public Item Take(string id)
        {
            Item item = Fetch(id);
            if (item != null)
            {
                _items.Remove(item);
            }
            return item;
        }

        public Item Fetch(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string itemList = "";
                foreach (Item item in _items)
                {
                    itemList += "\t" + item.ShortDescription + "\n";
                }
                return itemList;
            }
        }

    }
}
