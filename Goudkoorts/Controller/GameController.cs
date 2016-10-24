using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace Goudkoorts
{
    public class GameController
    {
        private int Score { get; set; }
        private int[] _startY = new int[3] { 1, 3, 5 };
        private BoardController _board;
        private DispatcherTimer _gameTimer;
        private MainWindow _view;
        private Random r;

        public GameController(MainWindow view)
        {
            _view = view;
            _board = new BoardController();
            _gameTimer = new DispatcherTimer();
            r = new Random();
            initLevel();

            _gameTimer.Interval = TimeSpan.FromMilliseconds(1000);
            _gameTimer.Tick += GameTimer;
            _gameTimer.Start();

        }

        public void initLevel()
        {
            List<BaseTile> tiles = _board.GetTiles();
            foreach (BaseTile tile in tiles)
            {
                _view.addVisualObject(tile);
            }
        }

        private void GameTimer(object sender, EventArgs e)
        {
            int tPoint = r.Next(1, 4);
            List<BaseTile> tileList = _board.GetTiles();
            for (int i = tileList.Count; i-- > 0;)
            {
                if(tileList[i].Cart != null)
                {
                    if (!CheckCartCollision(tileList[i]))
                        GameOver();

                    Cart t = tileList[i].Cart;
                    if (tileList[i].Next == null)
                    {
                        tileList[i].Cart = null;
                        _view.RemoveCart(tileList[i].Pos);
                    } else
                    {
                        if (CanMoveThroughSwitch(tileList[i]))
                        {
                            tileList[i].Next.Cart = t;
                            tileList[i].Cart = null;
                            _view.MoveCart(tileList[i].Pos, tileList[i].Next.Pos);
                        }
                    }
                }
            }

            Console.WriteLine(tPoint);
            if (CartStart())
            {
                Cart c = new Cart();
                _view.PlaceCart(_startY[tPoint - 1]);
                InsertCart(c, _startY[tPoint - 1]);
            }

        }

        private void GameOver()
        {
            _gameTimer.Stop();
            MessageBox.Show("Je hebt " + Score + " aantal punten.", "Game over");
        }

        private bool CheckCartCollision(BaseTile tile)
        {
            return tile.Next.Cart == null;
        }

        private bool CanMoveThroughSwitch(BaseTile tile)
        {
            return tile.Equals(tile.Next.Prev);
        }

        private bool CartStart()
        {
            return r.Next(0, 20) < 7 ? true : false;
        }

        private void InsertCart(Cart c, int startPoint)
        {
            foreach (BaseTile tile in _board.GetTiles())
            {
                if (tile.GetType() ==  typeof(StartTile))
                {
                    if(tile.Pos.Y == startPoint)
                    {
                        tile.Cart = c;
                    }
                }
            }
        }

        public void TurnSwitch(Point p)
        {
            _board.GetSwitchByPoint(p).Switch();
        }
    }
}