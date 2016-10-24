using Goudkoorts.Model.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Goudkoorts
{
    public abstract class BaseTile
    {
        public Point Pos { get; set; }
        public BaseTile Prev { get; set; }
        public BaseTile Next { get; set; }
        public BaseTile DisconnectedTile { get; set; }
        public Cart Cart { get; set; }
        public TileDirection Direction { get; set; }

        public virtual BaseTile ChainTiles(BaseTile tileTo)
        {
            if (tileTo != null)
            {
                this.Next = tileTo;

                if (tileTo.Prev == null)
                    tileTo.Prev = this;
                else
                    tileTo.DisconnectedTile = this;
            }

            return tileTo;
        }
    }
}