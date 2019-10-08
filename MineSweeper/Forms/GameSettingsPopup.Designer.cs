namespace MineSweeper.Forms
{
    partial class GameSettingsPopup
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.DefaultsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ColumnsSelector = new System.Windows.Forms.NumericUpDown();
            this.RowsSelector = new System.Windows.Forms.NumericUpDown();
            this.MinesSelector = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinesSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.StartGameButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.DefaultsButton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ColumnsSelector, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.RowsSelector, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.MinesSelector, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 161);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // StartGameButton
            // 
            this.StartGameButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartGameButton.Location = new System.Drawing.Point(3, 123);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(136, 35);
            this.StartGameButton.TabIndex = 0;
            this.StartGameButton.Text = "Start New Game";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // DefaultsButton
            // 
            this.DefaultsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DefaultsButton.Location = new System.Drawing.Point(145, 123);
            this.DefaultsButton.Name = "DefaultsButton";
            this.DefaultsButton.Size = new System.Drawing.Size(136, 35);
            this.DefaultsButton.TabIndex = 1;
            this.DefaultsButton.Text = "Defaults";
            this.DefaultsButton.UseVisualStyleBackColor = true;
            this.DefaultsButton.Click += new System.EventHandler(this.DefaultsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Columns";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rows";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mines";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColumnsSelector
            // 
            this.ColumnsSelector.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ColumnsSelector.Location = new System.Drawing.Point(153, 10);
            this.ColumnsSelector.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.ColumnsSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ColumnsSelector.Name = "ColumnsSelector";
            this.ColumnsSelector.Size = new System.Drawing.Size(120, 20);
            this.ColumnsSelector.TabIndex = 5;
            this.ColumnsSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RowsSelector
            // 
            this.RowsSelector.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RowsSelector.Location = new System.Drawing.Point(153, 50);
            this.RowsSelector.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.RowsSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RowsSelector.Name = "RowsSelector";
            this.RowsSelector.Size = new System.Drawing.Size(120, 20);
            this.RowsSelector.TabIndex = 6;
            this.RowsSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MinesSelector
            // 
            this.MinesSelector.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MinesSelector.Location = new System.Drawing.Point(153, 90);
            this.MinesSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinesSelector.Name = "MinesSelector";
            this.MinesSelector.Size = new System.Drawing.Size(120, 20);
            this.MinesSelector.TabIndex = 7;
            this.MinesSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // GameSettingsPopup
            // 
            this.AcceptButton = this.StartGameButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsPopup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Game";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GameSettingsPopup_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinesSelector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Button DefaultsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ColumnsSelector;
        private System.Windows.Forms.NumericUpDown RowsSelector;
        private System.Windows.Forms.NumericUpDown MinesSelector;
    }
}