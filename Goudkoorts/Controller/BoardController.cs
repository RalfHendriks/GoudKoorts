﻿using Goudkoorts.Controller;
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
        private FileParser _fp;

        public BoardController()
        {
            OpenLevel();
        }

        public void OpenLevel()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                _fp = new FileParser(openFileDialog.FileName);
            }
        }

        public List<BaseTile> GetTiles()
        {
            return _fp.GetTiles();
        }
        
        public SwitchTile GetSwitchByPoint(Point p)
        {
            var b = _fp.GetSwitches().Where(x => x.Pos.X == p.X && x.Pos.Y == p.Y);
            return (SwitchTile)_fp.GetSwitches().Where(x => x.Pos.Equals(p)).First();
        }
        
    }
}