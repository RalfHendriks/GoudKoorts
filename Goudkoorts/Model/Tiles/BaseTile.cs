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
        public Cart Cart { get; set; }
        public TileDirection Direction { get; set; }
    }
}