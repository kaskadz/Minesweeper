using System;
using System.Linq;

namespace MineSweeper.Logic
{
    internal class Solver : ISolver
    {
        private readonly SolvingContext _solvingContext;
        private readonly Board _board;

        private int _currentActionIndex;

        private static readonly Action<Solver>[] Actions =
        {
            ctx => ctx.Flag(),
            ctx => ctx.Dig()
        };

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
                PerformAction();
            }
        }

        private void PerformAction()
        {
            Actions[_currentActionIndex++](this);
            _currentActionIndex %= Actions.Length;
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
            _board.AllTiles
                .Where(tile => tile.State == TileState.Unflipped)
                .Random()
                .Flip();
        }
    }
}