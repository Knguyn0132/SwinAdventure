using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._1C
{
    public class LookCommand : Command
    {
        public LookCommand () : base(new string[] {"look"})
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look like that";
            }

            if (text[0] != "look")
            {
                return "Error in look input";
            }

            if (text[1] != "at")
            {
                return "What do you want to look at?";
            }

            if (text.Length == 5 && text[3] != "in")
            {
                return "What do you want to look in?";
            }

            IHaveInventory container;
            if (text.Length == 3)
            {
                
                container = FetchContainer(p, "inventory");
            }

            else
            {
                
                container = FetchContainer(p, text[4]);
                if (container == null)
                {
                    return $"I cannot find the {text[4]}";
                }
            }

            // Step 7: The item id is the 3rd word
            string itemId = text[2];
            return LookAtIn(itemId, container);

        }
        public IHaveInventory FetchContainer(Player p, string containerId)
        {
            if (containerId.ToLower() == "inventory")
            {
                return p;
            }
            
            GameObject obj = p.Locate(containerId);
            if (obj is IHaveInventory)
            {
                return (IHaveInventory)obj; //container is bag(?)
            }
            return null;
        }

        public string LookAtIn(string itemId, IHaveInventory container)
        {
            // Try to locate the item within the specified container
            GameObject item = container.Locate(itemId);
            if (item == null)
            {
                return $"I cannot find the {itemId} in {container.Name}";
            }
            ////            
            
            // Return the item's full description if found
            return item.FullDescription;
        }
    }
}
