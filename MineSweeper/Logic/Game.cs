using System;
using System.Linq;
using System.Windows.Forms;
using MineSweeper.Forms;

namespace MineSweeper.Logic
{
    internal class Game
    {
        private readonly GameBox _gameBox;
        private readonly GameSettings _gameSettings;
        private readonly ITileFactory _tileFactory;
        private readonly Timer _gameTimer;
        private readonly Board _board;

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

            _board = new Board(gameSettings);

            var tileCallbacks = new TileCallbacks(TileFlaggedCallback, TileFlippedCallback, BoomCallback);
            _tileFactory = new TileFactory(gameSettings, tileCallbacks, _board);

            _secondsElapsed = 0;
            _flaggedCount = 0;
            _flippedCount = 0;
            _state = GameState.NotStarted;
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
        }

        private void BoomCallback(ITile triggeredTile)
        {
            _gameTimer.Stop();
            _state = GameState.Failed;
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

        public void SetUp()
        {
            _gameBox.SetMinesLeftDisplay(_gameSettings.MinesCount);
            UpdateTimerDisplay();
            InitializeBoard();
        }

        public void CleanUp()
        {
            _gameTimer.Stop();
            _gameBox.ClearBoardPanel();
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

        private void InitializeBoard()
        {
            var tiles = Enumerable
                .Range(0, _gameSettings.Size)
                .ToList()
                .Shuffle()
                .Select(i => i < _gameSettings.MinesCount)
                .Select((hasMine, i) =>
                    (column: i / _gameSettings.Columns, row: i % _gameSettings.Rows, hasMine))
                .Select(x => _tileFactory.Create(x.column, x.row, x.hasMine))
                .ToList();

            tiles.ForEach(button => _board.AddTile(button));
            _gameBox.AddTiles(tiles);
        }
    }
}