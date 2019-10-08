using System;
using System.Windows.Forms;
using MineSweeper.Logic;

namespace MineSweeper.Forms
{
    public partial class GameBox : Form
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

        private void GameBox_Load(object sender, EventArgs e)
        {
        }
    }
}
