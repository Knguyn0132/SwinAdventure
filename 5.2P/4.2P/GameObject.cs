using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._2P
{
    public class GameObject : IdentifiableObject
    {
        private string _name;
        private string _description;

        public GameObject(string[] ids, string name, string description) : base(ids)    //call constructor of the base class
        {
            _name = name;
            _description = description;
        }   

        public string Name
        {
            get { return _name; }
        }

        public string ShortDescription
            { get { return $"{_name} ({FirstId})"; } }

        public virtual string FullDescription
            { get { return _description; } }
    }

}
