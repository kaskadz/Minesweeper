using System;
using System.Windows.Forms;
using MineSweeper.Logic;

namespace MineSweeper.Forms
{
    internal partial class GameSettingsPopup : Form
    {
        public GameSettings GameSettings { get; private set; }

        private GameSettings CreateGameSettings() =>
            new GameSettings((int)RowsSelector.Value, (int)ColumnsSelector.Value, (int)MinesSelector.Value);

        public GameSettingsPopup(GameSettings initialGameSettings)
        {
            InitializeComponent();
            GameSettings = initialGameSettings;
        }

        private void GameSettingsPopup_Load(object sender, EventArgs e) => SetSelectorValues(GameSettings ?? GameSettings.Default);

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            if (RowsSelector.Validate() &&
                ColumnsSelector.Validate() &&
                MinesSelector.Validate() &&
                RowsSelector.Value * ColumnsSelector.Value > MinesSelector.Value)
            {
                GameSettings = CreateGameSettings();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void DefaultsButton_Click(object sender, EventArgs e) => SetSelectorValues(GameSettings.Default);

        private void SetSelectorValues(GameSettings gameSettings)
        {
            RowsSelector.Value = gameSettings.Rows;
            ColumnsSelector.Value = gameSettings.Columns;
            MinesSelector.Value = gameSettings.MinesCount;
        }
    }
}
