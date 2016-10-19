using Goudkoorts.Model.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class SwitchTile : BaseTile
    {
        public BaseTile DisconnectedTile;
        public TileType Type { get; set; }

        public void Switch()
        {
            if(Type == TileType.Forward)
            {
                this.SwitchNext();
            }

            if (Type == TileType.Backward)
            {
                this.SwitchPrev();
            }
        }

        private void SwitchNext()
        {
            BaseTile oldNext = this.Next;
            this.Next = DisconnectedTile;
            DisconnectedTile = oldNext;
        }

        private void SwitchPrev()
        {
            BaseTile oldPrev = this.Prev;
            this.Prev = DisconnectedTile;
            DisconnectedTile = oldPrev;
        }
    }
}