namespace MineSweeper.Forms
{
    partial class GameBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BoardPanel = new System.Windows.Forms.Panel();
            this.MenuLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.MinesLeftCounter = new System.Windows.Forms.Label();
            this.TimerDisplay = new System.Windows.Forms.Label();
            this.LayoutPanel.SuspendLayout();
            this.MenuLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.ColumnCount = 1;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Controls.Add(this.BoardPanel, 0, 1);
            this.LayoutPanel.Controls.Add(this.MenuLayoutPanel, 0, 0);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 2;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutPanel.Size = new System.Drawing.Size(506, 546);
            this.LayoutPanel.TabIndex = 0;
            this.LayoutPanel.UseWaitCursor = true;
            // 
            // BoardPanel
            // 
            this.BoardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoardPanel.Location = new System.Drawing.Point(3, 43);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.Size = new System.Drawing.Size(500, 500);
            this.BoardPanel.TabIndex = 0;
            this.BoardPanel.UseWaitCursor = true;
            // 
            // MenuLayoutPanel
            // 
            this.MenuLayoutPanel.ColumnCount = 7;
            this.MenuLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MenuLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MenuLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.MenuLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MenuLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.MenuLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MenuLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MenuLayoutPanel.Controls.Add(this.NewGameButton, 3, 0);
            this.MenuLayoutPanel.Controls.Add(this.MinesLeftCounter, 1, 0);
            this.MenuLayoutPanel.Controls.Add(this.TimerDisplay, 5, 0);
            this.MenuLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.MenuLayoutPanel.Name = "MenuLayoutPanel";
            this.MenuLayoutPanel.RowCount = 1;
            this.MenuLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MenuLayoutPanel.Size = new System.Drawing.Size(500, 34);
            this.MenuLayoutPanel.TabIndex = 1;
            this.MenuLayoutPanel.UseWaitCursor = true;
            // 
            // NewGameButton
            // 
            this.NewGameButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewGameButton.Location = new System.Drawing.Point(178, 3);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(144, 28);
            this.NewGameButton.TabIndex = 0;
            this.NewGameButton.Text = "New Game";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.UseWaitCursor = true;
            this.NewGameButton.Click += new System.EventHandler(this.StartGame);
            // 
            // MinesLeftCounter
            // 
            this.MinesLeftCounter.AutoSize = true;
            this.MinesLeftCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MinesLeftCounter.Location = new System.Drawing.Point(53, 0);
            this.MinesLeftCounter.Name = "MinesLeftCounter";
            this.MinesLeftCounter.Size = new System.Drawing.Size(94, 34);
            this.MinesLeftCounter.TabIndex = 1;
            this.MinesLeftCounter.Text = "0000";
            this.MinesLeftCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MinesLeftCounter.UseWaitCursor = true;
            // 
            // TimerDisplay
            // 
            this.TimerDisplay.AutoSize = true;
            this.TimerDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimerDisplay.Location = new System.Drawing.Point(353, 0);
            this.TimerDisplay.Name = "TimerDisplay";
            this.TimerDisplay.Size = new System.Drawing.Size(94, 34);
            this.TimerDisplay.TabIndex = 2;
            this.TimerDisplay.Text = "0000";
            this.TimerDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TimerDisplay.UseWaitCursor = true;
            // 
            // GameBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 546);
            this.Controls.Add(this.LayoutPanel);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.UseWaitCursor = true;
            this.LayoutPanel.ResumeLayout(false);
            this.MenuLayoutPanel.ResumeLayout(false);
            this.MenuLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private System.Windows.Forms.TableLayoutPanel MenuLayoutPanel;
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Panel BoardPanel;
        private System.Windows.Forms.Label MinesLeftCounter;
        private System.Windows.Forms.Label TimerDisplay;
    }
}