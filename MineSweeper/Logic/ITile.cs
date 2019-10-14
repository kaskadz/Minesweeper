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
        TileState State { get; }
        TileButton TileButton { get; }
        void Flip();
        void Flag();
        void FlipNearbyIfCold();
        void RevealMineAndLock(ITile triggeredTile);
        IEnumerable<ITile> NeighborsInStates(params TileState[] states);
    }
}