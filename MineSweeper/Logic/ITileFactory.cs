namespace MineSweeper.Logic
{
    internal interface ITileFactory
    {
        ITile Create(int column, int row, bool hasMine);
    }
}