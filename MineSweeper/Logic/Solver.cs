using System.Linq;

namespace MineSweeper.Logic
{
    internal class Solver
    {
        private readonly SolvingContext _solvingContext;
        private readonly Board _board;

        public Solver(SolvingContext solvingContext, Board board)
        {
            _solvingContext = solvingContext;
            _board = board;
        }

        public void RegisterFlip(ITile flippedTile) =>
            _solvingContext.RegisterFlip(flippedTile);

        public void Step()
        {
            if (IsStuck())
            {
                UnflipRandomTile();
            }
            else
            {
                Flag();
                Dig();
            }
        }

        private bool IsStuck() =>
            !(_solvingContext.UnflaggedMines().Any() ||
              _solvingContext.UnflippedSafeTiles().Any());

        private void Flag()
        {
            _solvingContext.UnflaggedMines()
                .ForEach(tile => tile.Flag());
        }

        private void Dig()
        {
            _solvingContext.UnflippedSafeTiles()
                .ForEach(tile => tile.Flip());
        }

        private void UnflipRandomTile()
        {
            ITile startingTile = _board.AllTiles
                .Where(tile => tile.State == TileState.Unflipped)
                .RandomOrDefault();
            startingTile?.Flip();
        }
    }
}