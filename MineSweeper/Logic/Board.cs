namespace MineSweeper.Logic
{
    internal class Board
    {
        private readonly ITile[,] _board;

        public GameSettings GameSettings { get; }

        public Board(GameSettings gameSettings)
        {
            GameSettings = gameSettings;
            _board = new ITile[gameSettings.Columns, gameSettings.Rows];
        }

        public ITile this[int column, int row]
        {
            get => _board[column, row];
            set => _board[column, row] = value;
        }

        public void RevealMinesAndLockAll(ITile triggeredTile)
        {
            foreach (ITile tile in _board)
            {
                tile.RevealMineAndLock(triggeredTile);
            }
        }

        public void FlipNearbyIfCold(ITile flippedTile)
        {
            if (flippedTile.Heat == 0)
            {
                foreach (ITile flippedTileNeighbor in flippedTile.Neighbors)
                {
                    if (flippedTileNeighbor.State == TileState.Unfilpped)
                    {
                        flippedTileNeighbor.Flip();
                    }
                }
            }
        }
    }
}