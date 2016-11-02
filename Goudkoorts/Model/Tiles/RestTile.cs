using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class RestTile : BaseTile
    {
        public override bool CheckIfCollission()
        {
            // Never a collision on a rest tile
            return false;
        }

        protected override bool ShouldRemoveCart()
        {
            // Never remove a cart of rest tile (if no next tile)
            return false;
        }
    }
}