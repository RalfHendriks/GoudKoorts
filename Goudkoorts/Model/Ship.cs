using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Ship
    {
        private int _maxLoad { get; set; }
        public int CurrentLoad { get; set; }
        public bool IsDocked { get; set; }

        public Ship()
        {
            _maxLoad = 500;
        }

        public bool IsFull()
        {
            return CurrentLoad >= _maxLoad ? true : false;
        }
    }
}