using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._1C
{
    public interface IHaveInventory
    {
        GameObject Locate(string id); //locate item
        string Name { get; } //a name property
    }
}
