using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MineSweeper.Logic
{
    internal class Tile : Button, ITile
    {
        private readonly Board _board;
        private readonly Lazy<int> _lazyHeat;
        private readonly Lazy<IReadOnlyCollection<ITile>> _lazyNeighbors;
        private readonly TileCallbacks _tileCallbacks;

        public bool HasMine { get; }
        public int Heat => _lazyHeat.Value;
        public IReadOnlyCollection<ITile> Neighbors => _lazyNeighbors.Value;
        public TileState State { get; private set; }

        public Tile(int column, int row, bool hasMine, Board board, TileCallbacks tileCallbacks)
        {
            _board = board;
            _tileCallbacks = tileCallbacks;
            _lazyHeat = new Lazy<int>(CalculateHeat);
            _lazyNeighbors = new Lazy<IReadOnlyCollection<ITile>>(() => GetNeighbors(column, row).ToArray());
            HasMine = hasMine;
            SetState(TileState.Unfilpped);
            MouseUp += OnMouseUp;
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    ToggleFlag();
                    break;
                case MouseButtons.Left:
                    Flip();
                    break;
            }
        }

        private int CalculateHeat() => Neighbors.Count(tile => tile.HasMine);

        private IEnumerable<ITile> GetNeighbors(int column, int row)
        {
            int[] deltas = { -1, 0, 1 };
            foreach (int dx in deltas)
            {
                foreach (int dy in deltas)
                {
                    if (!(dx == 0 && dy == 0))
                    {
                        var (x, y) = (column + dx, row + dy);
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

        public void Flip()
        {
            if (State == TileState.Unfilpped)
            {
                if (HasMine)
                {
                    SetState(TileState.Boom);
                    _tileCallbacks.BoomCallback(this);
                }
                else
                {
                    SetState(TileState.Clear);
                    _tileCallbacks.TileFlippedCallback(this);
                }
            }
        }

        private void ToggleFlag()
        {
            switch (State)
            {
                case TileState.Unfilpped:
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

        private void Flag()
        {
            SetState(TileState.Flagged);
            _tileCallbacks.TileFlaggedCallback(true);
        }

        private void UnFlag()
        {
            SetState(TileState.Unfilpped);
            _tileCallbacks.TileFlaggedCallback(false);
        }

        private void SetState(TileState state)
        {
            State = state;
            switch (state)
            {
                case TileState.Unfilpped:
                    BackColor = Color.DarkGray;
                    BackgroundImage = null;
                    Text = "";
                    break;
                case TileState.Clear:
                    BackColor = Color.WhiteSmoke;
                    BackgroundImage = null;
                    Text = Heat == 0 ? "" : Heat.ToString();
                    break;
                case TileState.Flagged:
                    BackColor = Color.Coral;
                    BackgroundImage = Properties.Resources.Flag;
                    break;
                case TileState.Boom:
                    BackColor = Color.Red;
                    BackgroundImage = null;
                    BackgroundImage = Properties.Resources.Mine;
                    break;
                case TileState.UnflaggedMine:
                    BackColor = Color.HotPink;
                    BackgroundImage = null;
                    BackgroundImage = Properties.Resources.Mine;
                    break;
                case TileState.CorrectlyFlaggeed:
                    BackColor = Color.ForestGreen;
                    BackgroundImage = null;
                    BackgroundImage = Properties.Resources.Mine;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        public void RevealMineAndLock(ITile triggeredTile)
        {
            if (HasMine && this != triggeredTile)
            {
                SetState(
                    State == TileState.Flagged
                    ? TileState.CorrectlyFlaggeed
                    : TileState.UnflaggedMine);
            }
            Enabled = false;
        }
    }
}