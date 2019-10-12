using System.Collections.Generic;
using MineSweeper.Forms;

namespace MineSweeper.Logic
{
    internal interface ITile
    {
        int Column { get; }
        int Row { get; }
        int Heat { get; }
        bool HasMine { get; }
        TileButton TileButton { get; }
        IReadOnlyCollection<ITile> Neighbors { get; }
        TileState State { get; }
        void Flip();
        void RevealMineAndLock(ITile triggeredTile);
        void FlipNearbyIfCold();
    }
}