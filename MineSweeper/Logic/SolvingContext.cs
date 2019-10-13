using System.Collections.Generic;
using System.Linq;

namespace MineSweeper.Logic
{
    internal class SolvingContext
    {
        private readonly Board _board;
        private readonly LinkedList<ITile> _tilesInContext;

        public SolvingContext(Board board)
        {
            _board = board;
            _tilesInContext = new LinkedList<ITile>();
        }

        public void RegisterFlip(ITile flippedTile)
        {
            if (!flippedTile.HasMine && flippedTile.Heat > 0)
            {
                _tilesInContext.AddLast(flippedTile);
            }
        }

        public IList<ITile> UnflaggedMines()
        {
            return _tilesInContext
                .Where(tile => tile.NeighborsInStates(TileState.Unflipped, TileState.Flagged).Count() == tile.Heat)
                .SelectMany(tile => tile.NeighborsInStates(TileState.Unflipped))
                .ToList();
        }

        public IList<ITile> UnflippedSafeTiles()
        {
            return _tilesInContext
                .Where(tile => tile.NeighborsInStates(TileState.Flagged).Count() == tile.Heat)
                .SelectMany(tile => tile.NeighborsInStates(TileState.Unflipped))
                .ToList();
        }
    }
}