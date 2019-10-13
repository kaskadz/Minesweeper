using System.Collections.Generic;
using System.Linq;

namespace MineSweeper.Logic
{
    internal class Board
    {
        private readonly ITile[,] _board;

        public GameSettings GameSettings { get; }
        public IEnumerable<ITile> AllTiles => _board.Cast<ITile>();

        public Board(GameSettings gameSettings)
        {
            GameSettings = gameSettings;
            _board = new ITile[gameSettings.Columns, gameSettings.Rows];
        }

        public ITile this[int column, int row] => _board[column, row];

        public void AddTile(ITile tile) =>
            _board[tile.Column, tile.Row] = tile;

        public void RevealMinesAndLockAll(ITile triggeredTile) =>
            AllTiles.ForEach(tile => tile.RevealMineAndLock(triggeredTile));
    }
}