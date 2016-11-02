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

        public virtual void DoAction(GameController gameController)
        {
            if (Cart != null)
            {
                if (CanMove())
                {
                    MoveCart();
                    gameController.MoveCart(Pos, Next.Pos);
                }

                if (ShouldRemoveCart())
                {
                    Cart = null;
                    gameController.RemoveCart(Pos);
                }
            }
        }

        public virtual bool CheckIfCollission()
        {
            if (Cart != null && Next != null && Next.Prev == this && Next.Cart != null)
                return true;
            else
                return false;
        }

        protected virtual bool CanMove()
        {
            if (Next != null && Next.Prev != null && Next.Prev == this && Next.CanPlaceCart())
                return true;
            else
                return false;
        }

        protected virtual void MoveCart()
        {
            Next.Cart = Cart;
            Cart = null;
        }

        protected virtual bool CanPlaceCart()
        {
            if (Cart == null)
                return true;
            else
                return false;
        }

        protected virtual bool ShouldRemoveCart()
        {
            if (Next == null)
                return true;
            else
                return false;
        }
    }
}