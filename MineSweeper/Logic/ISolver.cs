namespace MineSweeper.Logic
{
    internal interface ISolver
    {
        void RegisterFlip(ITile flippedTile);
        void Step();
    }
}