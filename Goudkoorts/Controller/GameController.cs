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

            _gameTimer.Interval = TimeSpan.FromMilliseconds(200);
            _gameTimer.Tick += Game_Timer;
            _gameTimer.Start();
        }

        private void Game_Timer(object sender, EventArgs e)
        {
            _view.addVisualObject(null);
            Console.WriteLine(e);
        }
    }
}