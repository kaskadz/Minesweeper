using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MineSweeper.Logic;

namespace MineSweeper.Forms
{
    internal partial class GameBox : Form
    {
        private Game _game;

        public GameBox()
        {
            InitializeComponent();
        }

        private void StartGame(object caller, EventArgs e)
        {
            using (var popup = new GameSettingsPopup())
            {
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    _game?.CleanUp();

                    _game = new Game(this, popup.GameSettings);
                    _game.SetUp();
                }
            }
        }

        public void ClearBoardPanel() => BoardPanel.Controls.Clear();

        public void AddTiles(IEnumerable<ITile> tiles)
        {
            var tileButtons = tiles
                .Select(tile => tile.TileButton)
                .Cast<Control>()
                .ToArray();
            BoardPanel.Controls.AddRange(tileButtons);
        }

        public void SetMinesLeftDisplay(int minesLeftCount) =>
            MinesLeftCounter.Text = minesLeftCount.ToString("0000");

        public void SetTimerDisplayState(int timeElapsed) =>
            TimerDisplay.Text = timeElapsed.ToString("0000");

        private void Flag(object sender, EventArgs e)
        {
            _game?.Step();
        }

        private void Dig(object sender, EventArgs e)
        {
            _game?.Solve();
        }
    }
}
