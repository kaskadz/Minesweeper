using System.Collections.Generic;

namespace MineSweeper.Logic
{
    internal interface ITile
    {
        int Heat { get; }
        bool HasMine { get; }
        IReadOnlyCollection<ITile> Neighbors { get; }
        TileState State { get; }
        void Flip();
        void RevealMineAndLock(ITile triggeredTile);
    }
}