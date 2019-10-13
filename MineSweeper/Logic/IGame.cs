namespace MineSweeper.Logic
{
    internal interface IGame
    {
        void SetUp();
        void CleanUp();
        void Step();
        void Solve();
    }
}