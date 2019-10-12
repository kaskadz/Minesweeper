using System;
using System.Drawing;
using System.Windows.Forms;
using MineSweeper.Logic;

namespace MineSweeper.Forms
{
    internal class TileButton : Button
    {
        public void UpdateAppearance(ITile tile)
        {
            switch (tile.State)
            {
                case TileState.Unfilpped:
                    BackColor = Color.DarkGray;
                    BackgroundImage = null;
                    Text = "";
                    break;
                case TileState.Clear:
                    BackColor = Color.WhiteSmoke;
                    BackgroundImage = null;
                    Text = tile.Heat == 0 ? "" : tile.Heat.ToString();
                    break;
                case TileState.Flagged:
                    BackColor = Color.Coral;
                    BackgroundImage = Properties.Resources.Flag;
                    break;
                case TileState.Boom:
                    BackColor = Color.Red;
                    BackgroundImage = null;
                    BackgroundImage = Properties.Resources.Mine;
                    break;
                case TileState.UnflaggedMine:
                    BackColor = Color.HotPink;
                    BackgroundImage = null;
                    BackgroundImage = Properties.Resources.Mine;
                    break;
                case TileState.CorrectlyFlagged:
                    BackColor = Color.ForestGreen;
                    BackgroundImage = null;
                    BackgroundImage = Properties.Resources.Mine;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tile.State), tile.State, null);
            }
        }
    }
}