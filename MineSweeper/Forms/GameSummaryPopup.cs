using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MineSweeper.Logic;

namespace MineSweeper.Forms
{
    internal partial class GameSummaryPopup : Form
    {
        private const int RowHeight = 30;
        private readonly TableLayoutPanel _statsPanel;
        private readonly GameSummary _gameSummary;

        public GameSummaryPopup(GameSummary gameSummary)
        {
            _gameSummary = gameSummary;
            InitializeComponent();

            _statsPanel = new TableLayoutPanel();
            LayoutPanel.Controls.Add(_statsPanel, 0, 1);

            _statsPanel.TabIndex = 2;
            _statsPanel.ColumnCount = 2;
            _statsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _statsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _statsPanel.Dock = DockStyle.Fill;
            _statsPanel.Name = "StatsPanel";
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GameSummaryPopup_Load(object sender, EventArgs e)
        {
            GameResultLabel.Text = _gameSummary.Won ? "Won!" : "Lost :P";

            IEnumerable<(string description, string value)> rows = _gameSummary
                .GetSummaryRows()
                .ToList();

            IEnumerable<(Label description, Label value, int i)> labelRows = rows
                .Select((row, i) => (CreateLabel(row.description), CreateLabel(row.value), i));

            CreateRows(rows.Count());
            SetWindowHeight(rows.Count());
            foreach (var (description, value, i) in labelRows)
            {
                _statsPanel.Controls.Add(description, 0, i);
                _statsPanel.Controls.Add(value, 1, i);
            }
        }

        private void SetWindowHeight(int count)
        {
            const int windowFrameHeight = 31 + 8;
            const int resultRowHeight = 45;
            const int okButtonHeight = 40;
            Height = windowFrameHeight + resultRowHeight + okButtonHeight + count * RowHeight;
        }

        private void CreateRows(int rowCount)
        {
            _statsPanel.RowCount = rowCount;
            int height = 100 / rowCount;
            for (int i = 0; i < rowCount; i++)
            {
                _statsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, height));
            }
        }

        private static Label CreateLabel(string text)
        {
            return new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = text
            };
        }

        private void GameSummaryPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            _statsPanel.Dispose();
        }
    }
}
