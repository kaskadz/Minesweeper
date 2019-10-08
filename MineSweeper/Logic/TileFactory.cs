using System;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper.Logic
{
    internal class TileFactory : ITileFactory
    {
        private readonly TileCallbacks _tileCallbacks;
        private readonly Board _board;
        private Point _startPosition;
        private readonly int _tileSize;

        public TileFactory(GameSettings gameSettings, TileCallbacks tileCallbacks, Board board)
        {
            _tileCallbacks = tileCallbacks;
            _board = board;
            _tileSize = 500 / Math.Max(gameSettings.Columns, gameSettings.Rows);
            _startPosition = gameSettings.Rows > gameSettings.Columns
                ? new Point(((gameSettings.Rows - gameSettings.Columns) * _tileSize) / 2, 0)
                : new Point(0, ((gameSettings.Columns - gameSettings.Rows) * _tileSize) / 2);
        }

        public Tile Create(int column, int row, bool hasMine)
        {
            var tile = new Tile(column, row, hasMine, _board, _tileCallbacks)
            {
                Size = new Size(_tileSize, _tileSize),
                Location = TileLocation(column, row),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    BorderSize = 1,
                    BorderColor = Color.Gray
                },
                BackgroundImageLayout = ImageLayout.Stretch
            };

            return tile;
        }

        private Point TileLocation(int column, int row) =>
            new Point(_startPosition.X + _tileSize * column, _startPosition.Y + _tileSize * row);
    }
}