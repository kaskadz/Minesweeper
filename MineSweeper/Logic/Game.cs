using System;
using System.Windows.Forms;
using MineSweeper.Forms;

namespace MineSweeper.Logic
{
    internal class Game : IGame
    {
        private readonly GameBox _gameBox;
        private readonly GameSettings _gameSettings;
        private readonly Timer _gameTimer;
        private readonly Board _board;
        private readonly Solver _solver;

        private GameState _state;
        private int _secondsElapsed;
        private int _flaggedCount;
        private int _flippedCount;

        public Game(GameBox gameBox, GameSettings gameSettings)
        {
            _gameBox = gameBox;
            _gameSettings = gameSettings;

            _gameTimer = new Timer { Interval = 1000 };
            _gameTimer.Tick += UpdateTimerDisplay;

            var tileCallbacks = new TileCallbacks(TileFlaggedCallback, TileFlippedCallback, BoomCallback);
            _board = new Board(gameSettings, tileCallbacks);
            _solver = new Solver(new SolvingContext(), _board);

            _secondsElapsed = 0;
            _flaggedCount = 0;
            _flippedCount = 0;
            _state = GameState.NotStarted;
        }

        public void SetUp()
        {
            UpdateMinesLeftDisplay();
            UpdateTimerDisplay();
            _board.InitializeBoard();
            _gameBox.AddTiles(_board.AllTiles);
        }

        public void CleanUp()
        {
            _gameTimer.Stop();
            _gameBox.ClearBoardPanel();
        }

        public void Step()
        {
            if (_state.In(GameState.InProgress, GameState.NotStarted))
            {
                _solver.Step();
            }
        }

        public void Solve()
        {
            while (_state.In(GameState.InProgress, GameState.NotStarted))
            {
                _solver.Step();
            }
        }

        private void TileFlaggedCallback(bool enableFlag)
        {
            _flaggedCount += enableFlag ? 1 : -1;
            UpdateMinesLeftDisplay();
        }

        private void TileFlippedCallback(ITile flippedTile)
        {
            StartIfNotAlreadyStarted();
            flippedTile.FlipNearbyIfCold();
            IncrementFlipCountAndCheckIfWon();
            _solver.RegisterFlip(flippedTile);
        }

        private void BoomCallback(ITile triggeredTile)
        {
            _gameTimer.Stop();
            _state = GameState.Lost;
            _board.RevealMinesAndLockAll(triggeredTile);
        }

        private void IncrementFlipCountAndCheckIfWon()
        {
            if (++_flippedCount == _gameSettings.Size - _gameSettings.MinesCount)
            {
                _gameTimer.Stop();
                _state = GameState.Won;
                _board.RevealMinesAndLockAll(null);
            }
        }

        private void StartIfNotAlreadyStarted()
        {
            if (_state == GameState.NotStarted)
            {
                _state = GameState.InProgress;
                _gameTimer.Start();
            }
        }

        private void UpdateTimerDisplay(object sender, EventArgs e)
        {
            _secondsElapsed += 1;
            UpdateTimerDisplay();
        }

        private void UpdateMinesLeftDisplay() =>
            _gameBox.SetMinesLeftDisplay(_gameSettings.MinesCount - _flaggedCount);

        private void UpdateTimerDisplay() =>
            _gameBox.SetTimerDisplayState(_secondsElapsed);
    }
}