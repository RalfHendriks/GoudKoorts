using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class ShipTile : BaseTile
    {
        public override void DoAction(GameController gameController)
        {
            if(Cart != null)
            {
                if (CanMove() && gameController.ShipIsDocked())
                {
                    gameController.EmptyCart();
                    gameController.AddShipLoad();
                    gameController.RefreshShipLoad();
                    gameController.UpdateScore(1);
                }
            }

            base.DoAction(gameController);
        }
    }
}