using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MineSweeper.Logic;

namespace MineSweeper.Forms
{
    internal partial class GameBox : Form
    {
        private IGame _game;
        private GameSettings _lastGameSettings;

        public GameBox()
        {
            InitializeComponent();
        }

        public void AddTiles(IEnumerable<ITile> tiles)
        {
            var tileButtons = tiles
                .Select(tile => tile.TileButton)
                .Cast<Control>()
                .ToArray();
            BoardPanel.Controls.AddRange(tileButtons);
        }

        public void ClearBoardPanel() => BoardPanel.Controls.Clear();

        public void SetMinesLeftDisplay(int minesLeftCount) =>
            MinesLeftCounter.Text = minesLeftCount.ToString("0000");

        public void SetTimerDisplayState(int timeElapsed) =>
            TimerDisplay.Text = timeElapsed.ToString("0000");

        private void StartGame(object caller, EventArgs e)
        {
            using (var popup = new GameSettingsPopup(_lastGameSettings))
            {
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    _game?.CleanUp();

                    _lastGameSettings = popup.GameSettings;
                    _game = new Game(this, _lastGameSettings);
                    _game.SetUp();
                }
            }
        }

        private void Step(object sender, EventArgs e) => _game?.Step();

        private void Solve(object sender, EventArgs e) => _game?.Solve();

        public void ShowGameSummary(GameSummary gameSummary)
        {
            using (var popup = new GameSummaryPopup(gameSummary))
            {
                popup.ShowDialog();
            }
        }
    }
}
