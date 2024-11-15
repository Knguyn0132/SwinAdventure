using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1P
{
    public abstract class Command : IdentifiableObject //base class for other classes, cannot create an object
    {
        private string[] _ids;
        public Command(string[] ids) : base(ids) 
        {
            _ids = ids;
        }

        public abstract string Execute(Player p, string[] text); //define without implementation
         
        

    }
}
