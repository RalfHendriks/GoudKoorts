using Goudkoorts.Model.Tiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Goudkoorts.Controller
{
    class FileParser
    {
        private readonly string[] _file;
        private List<BaseTile> _tiles = new List<BaseTile>();
        private List<BaseTile> _switches = new List<BaseTile>();
        private List<BaseTile> _startTiles = new List<BaseTile>();

        public FileParser(string path)
        {
            _file = File.ReadAllLines(path);
            ParseFile();
        } 

        public List<BaseTile> GetTiles()
        {
            return _tiles;
        }

        public List<BaseTile> GetSwitches()
        {
            return _switches;
        }

        public List<BaseTile> GetStartTiles()
        {
            return _startTiles;
        }

        private void ParseFile()
        {
            bool chain = false;

            foreach (var line in _file)
            {
                // Check for comments
                if (line.StartsWith("#"))
                    continue;

                // Check for empty line
                if (line.Length == 0)
                {
                    chain = true;
                    continue;
                }

                // Check if ready for chaining
                if (!chain)
                    ParseLine(line);
                else
                    ChainTiles(line);
            }
        }

        private void ParseLine(string line)
        {
            // Remove tab and space elements
            line = Regex.Replace(line, @"[\t|\s]", string.Empty);

            // Split on each column (seperated by ':')
            var column = line.Split(':');

            // Get position out of first column
            var aPos = column[0].Trim().Split(',');
            Point pos = new Point { X = Int32.Parse(aPos[0]), Y = Int32.Parse(aPos[1]) };

            // Create tile
            BaseTile tile = CreateTileByString(column[1].Trim());

            // Get direction
            TileDirection direction = (TileDirection)Enum.Parse(typeof(TileDirection), column[2].Trim());
            
            tile.Pos = pos;
            tile.Direction = direction;
            _tiles.Add(tile);
        }

        private void ChainTiles(string line)
        {
            // Remove tab and space elements
            line = Regex.Replace(line, @"[\t|\s]", string.Empty);

            // Split on each column (seperated by ':')
            var column = line.Split(':');

            // Get position out of first column
            var aPosFrom = column[0].Trim().Split(',');
            Point posFrom = new Point { X = Int32.Parse(aPosFrom[0]), Y = Int32.Parse(aPosFrom[1]) };

            // Get position out of second column
            var aPosTo = column[1].Trim().Split(',');
            Point posTo = new Point { X = Int32.Parse(aPosTo[0]), Y = Int32.Parse(aPosTo[1]) };

            // Chain them
            BaseTile tileFrom = _tiles.FirstOrDefault(item => item.Pos == posFrom);
            BaseTile tileTo = _tiles.FirstOrDefault(item => item.Pos == posTo);
            tileFrom.ChainTiles(tileTo);
        }

        private BaseTile CreateTileByString(string tileName)
        {
            BaseTile tile;
            switch (tileName)
            {
                case "Tile":
                    tile = new Tile();
                    break;
                case "Start":
                    tile = new StartTile();
                    _startTiles.Add(tile);
                    break;
                case "Rest":
                    tile = new RestTile();
                    break;
                case "Switch":
                    tile = new SwitchTile();
                    _switches.Add(tile);
                    break;
                case "Ship":
                    tile = new ShipTile();
                    break;
                default:
                    tile = new Tile();
                    break;
            }
            return tile;
        }

    }
}
