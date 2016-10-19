using Goudkoorts.Controller;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Goudkoorts
{
    public class BoardController
    {
        private List<BaseTile> _startPoints = new List<BaseTile>();
        private List<BaseTile> _switches = new List<BaseTile>();


        public BoardController()
        {
            /*OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FileParser fp = new FileParser(openFileDialog.FileName);
            }*/
        }
        
       /* private void CreateStartTiles()
        {
            _startPoints.Add(new Tile { Pos = new Point { X = 1, Y = 6 }, Type = "horizontal" });
            _startPoints.Add(new Tile { Pos = new Point { X = 1, Y = 4 }, Type = "horizontal" });
            _startPoints.Add(new Tile { Pos = new Point { X = 1, Y = 1 }, Type = "horizontal" });
        }

        private void CreateSwitches()
        {
            _switches.Add(new SwitchTile { Pos = new Point { X = 3, Y = 5 }, Type = "backward" });
            _switches.Add(new SwitchTile { Pos = new Point { X = 5, Y = 5 }, Type = "forward" });
            _switches.Add(new SwitchTile { Pos = new Point { X = 6, Y = 2 }, Type = "backward" });
            _switches.Add(new SwitchTile { Pos = new Point { X = 8, Y = 2 }, Type = "forward" });
            _switches.Add(new SwitchTile { Pos = new Point { X = 9, Y = 5 }, Type = "backward" });
        }

        private void CreateBoard()
        {
            BaseTile prevTile = null;
            SwitchTile switchTile = null;

            // Begin Route A
            prevTile = _startPoints.First(item => item.Pos.X == 1 && item.Pos.Y == 6);
            while(prevTile.Pos.X < 3)
            {
                prevTile.Next = new Tile { Pos = new Point { X = (prevTile.Pos.X + 1), Y = prevTile.Pos.Y }, Type = "horizontal" };
                prevTile.Next.Prev = prevTile;
                prevTile = prevTile.Next;
            }

            // Connect Route A with SwitchTile 1
            switchTile = (SwitchTile)_switches.First(item => item.Pos.X == 3 && item.Pos.Y == 5);
            switchTile.DisconnectedTile = prevTile;

            // Begin Route B
            prevTile = _startPoints.First(item => item.Pos.X == 1 && item.Pos.Y == 4);
            while (prevTile.Pos.X < 3)
            {
                prevTile.Next = new Tile { Pos = new Point { X = (prevTile.Pos.X + 1), Y = prevTile.Pos.Y }, Type = "horizontal" };
                prevTile.Next.Prev = prevTile;
                prevTile = prevTile.Next;
            }

            // Connect Route B with SwitchTile 1
            prevTile.Next = switchTile;
            switchTile.Prev = prevTile;

            // Connect SwitchTile 1 with SwitchTile 2
            //switchTile.Next = 


            // Begin Route C
            prevTile = _startPoints.First(item => item.Pos.X == 1 && item.Pos.Y == 1);
            while (prevTile.Pos.X < 6)
            {
                prevTile.Next = new Tile { Pos = new Point { X = (prevTile.Pos.X + 1), Y = prevTile.Pos.Y }, Type = "horizontal" };
                prevTile.Next.Prev = prevTile;
                prevTile = prevTile.Next;
            }

            // Begin Switch 1
            prevTile = _switches.First(item => item.Pos.X == 3 && item.Pos.Y == 5);
            
        }*/

    }
}