namespace MineSweeper.Logic
{
    internal interface ITileFactory
    {
        Tile Create(int column, int row, bool hasMine);
    }
}