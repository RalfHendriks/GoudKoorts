using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace Goudkoorts
{
    public class GameController
    {
        private int Score { get; set; }
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

            _gameTimer.Interval = TimeSpan.FromSeconds(1);
            _gameTimer.Tick += Game_Timer;
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

        private void Game_Timer(object sender, EventArgs e)
        {
            if (CartStart())
            {
                Cart c = new Cart();
                _view.AddCart(c);
            }
            _view.MoveObjects();
        }

        private bool CartStart()
        {
            return r.Next(0, 20) < 7 ? true : false;
        }
    }
}