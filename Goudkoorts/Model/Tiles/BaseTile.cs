using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public abstract class BaseTile
    {
        public BaseTile Next { get; set; }
        public Cart Cart { get; set; }
    }
}