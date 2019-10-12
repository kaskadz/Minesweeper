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

        public ITile Create(int column, int row, bool hasMine)
        {
            var tile = new Tile(column, row, hasMine, _board, _tileCallbacks);

            SetButtonProperties(column, row, tile.TileButton);

            return tile;
        }

        private void SetButtonProperties(int column, int row, ButtonBase button)
        {
            button.Size = new Size(_tileSize, _tileSize);
            button.Location = TileLocation(column, row);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.Gray;
            button.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private Point TileLocation(int column, int row) =>
            new Point(_startPosition.X + _tileSize * column, _startPosition.Y + _tileSize * row);
    }
}