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
        }


        public List<Player> Players{get; set;}



    }
}
