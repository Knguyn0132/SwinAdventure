using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1P
{
    public interface IHaveInventory
    {
        GameObject Locate(string id); //locate item
        string Name { get; } //a name property
    }
}
