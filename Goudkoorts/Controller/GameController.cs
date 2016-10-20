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

        public GameController(MainWindow view)
        {
            _view = view;
            _board = new BoardController();
            _gameTimer = new DispatcherTimer();

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
            Console.WriteLine(e);
        }
    }
}