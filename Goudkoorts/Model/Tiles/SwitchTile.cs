using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class SwitchTile : BaseTile
    {
        private BaseTile _disconnectedNext;

        public void SwitchNext()
        {
            BaseTile oldNext = this.Next;
            this.Next = _disconnectedNext;
            _disconnectedNext = oldNext;
        }
    }
}