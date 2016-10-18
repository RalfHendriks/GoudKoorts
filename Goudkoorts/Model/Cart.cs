using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Cart
    {
        private bool _isLoaded { get; set; }

        public bool IsLoaded
        {
            get { return _isLoaded; }
        }

        public Cart()
        {
            _isLoaded = true;
        }
    }
}