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

        private void BoomCallback(ITile triggeredTile)
        {
            _gameTimer.Stop();
            _state = GameState.Failed;
            _board.RevealMinesAndLockAll(triggeredTile);
        }

        private void TileFlippedCallback(ITile flippedTile)
        {
            StartIfNotAlreadyStarted();
            _board.FlipNearbyIfCold(flippedTile);
            IncrementFlipCountAndCheckIfWon();
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

        private void TileFlaggedCallback(bool enableFlag)
        {
            _flaggedCount += enableFlag ? 1 : -1;
            UpdateMinesLeftDisplay();
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
            _gameBox.MinesLeftCounter.Text = _gameSettings.MinesCount.ToString("0000");
            _gameBox.TimerDisplay.Text = "0000";
            InitializeBoard();
        }

        public void CleanUp()
        {
            _gameTimer.Stop();
            _gameBox.BoardPanel.Controls.Clear();
        }

        private void UpdateMinesLeftDisplay()
        {
            _gameBox.MinesLeftCounter.Text =
                (_gameSettings.MinesCount - _flaggedCount).ToString("0000");
        }

        private void UpdateTimerDisplay(object sender, EventArgs e)
        {
            _secondsElapsed += 1;
            _gameBox.TimerDisplay.Text = _secondsElapsed.ToString("0000");
        }

        private void InitializeBoard()
        {
            var mineDistribution = Enumerable
                .Range(0, _gameSettings.Size)
                .ToList()
                .Shuffle()
                .Select(i => i < _gameSettings.MinesCount);

            using (var hasMineStatus = mineDistribution.GetEnumerator())
            {
                for (int column = 0; column < _gameSettings.Columns; column++)
                {
                    for (int row = 0; row < _gameSettings.Rows; row++)
                    {
                        hasMineStatus.MoveNext();
                        var tile = _tileFactory.Create(column, row, hasMineStatus.Current);
                        _board[column, row] = tile;
                        _gameBox.BoardPanel.Controls.Add(tile);
                    }
                }
            }
        }
    }
}