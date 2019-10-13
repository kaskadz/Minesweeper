using System.Collections.Generic;
using System.Linq;

namespace MineSweeper.Logic
{
    internal class Board
    {
        private readonly ITile[,] _board;
        private readonly ITileFactory _tileFactory;

        public GameSettings GameSettings { get; }
        public IEnumerable<ITile> AllTiles => _board.Cast<ITile>();

        public Board(GameSettings gameSettings, TileCallbacks tileCallbacks)
        {
            GameSettings = gameSettings;
            _board = new ITile[gameSettings.Columns, gameSettings.Rows];
            _tileFactory = new TileFactory(gameSettings, tileCallbacks, this);
        }

        public ITile this[int column, int row] => _board[column, row];

        private void AddTile(ITile tile) => _board[tile.Column, tile.Row] = tile;

        public void RevealMinesAndLockAll(ITile triggeredTile) =>
            AllTiles.ForEach(tile => tile.RevealMineAndLock(triggeredTile));

        public void InitializeBoard()
        {
            Enumerable
                .Range(0, GameSettings.Size)
                .ToList()
                .Shuffle()
                .Select(i => i < GameSettings.MinesCount)
                .Select((hasMine, i) => (hasMine, i))
                .Select(tuple =>
                    (column: tuple.i % GameSettings.Columns, row: tuple.i / GameSettings.Columns, tuple.hasMine))
                .Select(x => _tileFactory.Create(x.column, x.row, x.hasMine))
                .ForEach(AddTile);
        }
    }
}