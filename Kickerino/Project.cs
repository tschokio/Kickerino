using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kickerino
{
    public  class Project
    {
        public Project()
        {
            Players = new List<Player>();
            Squad = new List<Player>();
        }


        public List<Player> Players{ get; set;}
        public List<Player> Squad { get; set;} //temporary list used for the second combobox
        public int startingNumber { get; set; }
        public int endingNumber { get; set; }



    }
}
