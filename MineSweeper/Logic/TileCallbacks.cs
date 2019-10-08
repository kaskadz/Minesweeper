using System;

namespace MineSweeper.Logic
{
    internal class TileCallbacks
    {
        public Action<bool> TileFlaggedCallback { get; }
        public Action<ITile> TileFlippedCallback { get; }
        public Action<ITile> BoomCallback { get; }

        public TileCallbacks(Action<bool> tileFlaggedCallback, Action<ITile> tileFlippedCallback, Action<ITile> boomCallback)
        {
            TileFlaggedCallback = tileFlaggedCallback;
            TileFlippedCallback = tileFlippedCallback;
            BoomCallback = boomCallback;
        }
    }
}