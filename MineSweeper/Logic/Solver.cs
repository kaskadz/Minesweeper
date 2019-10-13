using System.Linq;

namespace MineSweeper.Logic
{
    internal class Solver
    {
        private readonly SolvingContext _solvingContext;

        public Solver(SolvingContext solvingContext)
        {
            _solvingContext = solvingContext;
        }

        public bool IsStuck()
        {
            return !(_solvingContext.UnflaggedMines().Any() ||
                     _solvingContext.UnflippedSafeTiles().Any());
        }

        public void Step()
        {
            Flag();
            Dig();
        }

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
    }
}