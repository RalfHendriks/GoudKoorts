using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public abstract class BaseTile : ITile
    {
        public ITile Next { get; set; }
        public ITile Previous { get; set; }
        public Cart Cart {get; set;}
    }
}