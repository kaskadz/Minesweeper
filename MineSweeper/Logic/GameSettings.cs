namespace MineSweeper.Logic
{
    internal class GameSettings
    {
        public static GameSettings Default => new GameSettings(10, 10, 10);

        public GameSettings(int rows, int columns, int minesCount)
        {
            Rows = rows;
            Columns = columns;
            MinesCount = minesCount;
        }

        public int Rows { get; }
        public int Columns { get; }
        public int MinesCount { get; }
        public int Size => Columns * Rows;
    }
}