using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._1C
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();
        public IdentifiableObject(string[] identifiers)
        {


            foreach (string id in identifiers)
            {
                AddIdentifier(id);
            }
        }

        public void AddIdentifier(string identifier)
        {
            _identifiers.Add(identifier.ToLower());
        }

        public bool AreYou(string identifier)
        { return _identifiers.Contains(identifier.ToLower()); }

        public string FirstId
        {
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }
                else
                {
                    return "";
                }
            }
        }



        public void PrivilegeEscalation(string pin)
        {
            if (pin == "2183" && _identifiers.Count > 0)
            {
                _identifiers[0] = "7";
            }
        }
    }
}
