using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MineSweeper.Forms;

namespace MineSweeper.Logic
{
    internal class Tile : ITile
    {
        private readonly Board _board;
        private readonly Lazy<int> _lazyHeat;
        private readonly Lazy<IReadOnlyCollection<ITile>> _lazyNeighbors;
        private readonly TileCallbacks _tileCallbacks;
        private TileState _state;

        public TileButton TileButton { get; }
        public int Column { get; }
        public int Row { get; }
        public bool HasMine { get; }
        public int Heat => _lazyHeat.Value;
        public IReadOnlyCollection<ITile> Neighbors => _lazyNeighbors.Value;

        public TileState State
        {
            get => _state;
            private set
            {
                _state = value;
                TileButton.UpdateAppearance(this);
            }
        }

        public Tile(int column, int row, bool hasMine, Board board, TileCallbacks tileCallbacks)
        {
            _board = board;
            _tileCallbacks = tileCallbacks;
            _lazyHeat = new Lazy<int>(CalculateHeat);
            _lazyNeighbors = new Lazy<IReadOnlyCollection<ITile>>(() => GetNeighbors().ToArray());
            TileButton = new TileButton();
            TileButton.MouseUp += OnMouseUp;
            Column = column;
            Row = row;
            HasMine = hasMine;
            State = TileState.Unflipped;
        }

        public IEnumerable<ITile> NeighborsInStates(params TileState[] states) => Neighbors
            .Where(tile => tile.State.IsGameTimeState())
            .Where(tile => tile.State.In(states));

        public void Flip()
        {
            if (State == TileState.Unflipped)
            {
                if (HasMine)
                {
                    State = TileState.Boom;
                    _tileCallbacks.BoomCallback(this);
                }
                else
                {
                    State = TileState.Clear;
                    _tileCallbacks.TileFlippedCallback(this);
                }
            }
        }

        public void RevealMineAndLock(ITile triggeredTile)
        {
            if (HasMine && this != triggeredTile)
            {
                State =
                    State == TileState.Flagged
                        ? TileState.CorrectlyFlagged
                        : TileState.UnflaggedMine;
            }
            TileButton.Enabled = false;
        }

        public void FlipNearbyIfCold()
        {
            if (Heat == 0)
            {
                NeighborsInStates(TileState.Unflipped)
                    .ForEach(tile => tile.Flip());
            }
        }

        public void Flag()
        {
            State = TileState.Flagged;
            _tileCallbacks.TileFlaggedCallback(true);
        }

        public void UnFlag()
        {
            State = TileState.Unflipped;
            _tileCallbacks.TileFlaggedCallback(false);
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    ToggleFlag();
                    break;
                case MouseButtons.Left:
                    if (State == TileState.Unflipped)
                    {
                        Flip();
                    }
                    break;
            }
        }

        private int CalculateHeat() => Neighbors.Count(tile => tile.HasMine);

        private IEnumerable<ITile> GetNeighbors()
        {
            int[] deltas = { -1, 0, 1 };
            foreach (int dx in deltas)
            {
                foreach (int dy in deltas)
                {
                    if (!(dx == 0 && dy == 0))
                    {
                        var (x, y) = (Column + dx, Row + dy);
                        if (x >= 0 &&
                            y >= 0 &&
                            x < _board.GameSettings.Columns &&
                            y < _board.GameSettings.Rows)
                        {
                            yield return _board[x, y];
                        }
                    }
                }
            }
        }

        private void ToggleFlag()
        {
            switch (State)
            {
                case TileState.Unflipped:
                    Flag();
                    break;
                case TileState.Flagged:
                    UnFlag();
                    break;
                case TileState.Clear:
                case TileState.Boom:
                case TileState.UnflaggedMine:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(State), State, null);
            }
        }
    }
}