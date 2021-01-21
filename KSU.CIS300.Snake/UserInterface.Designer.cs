namespace KSU.CIS300.Snake
{
    partial class UserInterface
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
            this.uxMenuStrip = new System.Windows.Forms.MenuStrip();
            this.uxFile = new System.Windows.Forms.ToolStripMenuItem();
            this.uxNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.uxEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.uxNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.uxHard = new System.Windows.Forms.ToolStripMenuItem();
            this.uxIsAI = new System.Windows.Forms.CheckBox();
            this.uxLabelScore = new System.Windows.Forms.Label();
            this.uxScore = new System.Windows.Forms.Label();
            this.uxPictureBox = new System.Windows.Forms.PictureBox();
            this.uxDelay = new System.Windows.Forms.NumericUpDown();
            this.uxAiDeleyLabel = new System.Windows.Forms.Label();
            this.uxMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // uxMenuStrip
            // 
            this.uxMenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.uxMenuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.uxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxFile});
            this.uxMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.uxMenuStrip.Name = "uxMenuStrip";
            this.uxMenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.uxMenuStrip.Size = new System.Drawing.Size(904, 49);
            this.uxMenuStrip.TabIndex = 0;
            this.uxMenuStrip.Text = "menuStrip1";
            // 
            // uxFile
            // 
            this.uxFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxNewGame});
            this.uxFile.Name = "uxFile";
            this.uxFile.Size = new System.Drawing.Size(87, 45);
            this.uxFile.Text = "File";
            // 
            // uxNewGame
            // 
            this.uxNewGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxEasy,
            this.uxNormal,
            this.uxHard});
            this.uxNewGame.Name = "uxNewGame";
            this.uxNewGame.Size = new System.Drawing.Size(330, 54);
            this.uxNewGame.Text = "New Game";
            // 
            // uxEasy
            // 
            this.uxEasy.Name = "uxEasy";
            this.uxEasy.Size = new System.Drawing.Size(282, 54);
            this.uxEasy.Text = "Easy";
            this.uxEasy.Click += new System.EventHandler(this.uxEasy_Click);
            // 
            // uxNormal
            // 
            this.uxNormal.Name = "uxNormal";
            this.uxNormal.Size = new System.Drawing.Size(282, 54);
            this.uxNormal.Text = "Normal";
            this.uxNormal.Click += new System.EventHandler(this.uxNormal_Click);
            // 
            // uxHard
            // 
            this.uxHard.Name = "uxHard";
            this.uxHard.Size = new System.Drawing.Size(282, 54);
            this.uxHard.Text = "Hard";
            this.uxHard.Click += new System.EventHandler(this.uxHard_Click);
            // 
            // uxIsAI
            // 
            this.uxIsAI.AutoSize = true;
            this.uxIsAI.Location = new System.Drawing.Point(96, 12);
            this.uxIsAI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxIsAI.Name = "uxIsAI";
            this.uxIsAI.Size = new System.Drawing.Size(167, 36);
            this.uxIsAI.TabIndex = 1;
            this.uxIsAI.Text = "AI Player";
            this.uxIsAI.UseVisualStyleBackColor = true;
            this.uxIsAI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserInterface_KeyDown);
            this.uxIsAI.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserInterface_PreviewKeyDown);
            // 
            // uxLabelScore
            // 
            this.uxLabelScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxLabelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLabelScore.Location = new System.Drawing.Point(669, 10);
            this.uxLabelScore.Name = "uxLabelScore";
            this.uxLabelScore.Size = new System.Drawing.Size(131, 41);
            this.uxLabelScore.TabIndex = 2;
            this.uxLabelScore.Text = "Score";
            // 
            // uxScore
            // 
            this.uxScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxScore.Location = new System.Drawing.Point(787, 10);
            this.uxScore.Name = "uxScore";
            this.uxScore.Size = new System.Drawing.Size(101, 38);
            this.uxScore.TabIndex = 3;
            this.uxScore.Text = "2";
            // 
            // uxPictureBox
            // 
            this.uxPictureBox.Location = new System.Drawing.Point(0, 62);
            this.uxPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxPictureBox.Name = "uxPictureBox";
            this.uxPictureBox.Size = new System.Drawing.Size(493, 386);
            this.uxPictureBox.TabIndex = 4;
            this.uxPictureBox.TabStop = false;
            this.uxPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.uxPictureBox_Paint);
            // 
            // uxDelay
            // 
            this.uxDelay.Location = new System.Drawing.Point(440, 10);
            this.uxDelay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxDelay.Name = "uxDelay";
            this.uxDelay.Size = new System.Drawing.Size(120, 38);
            this.uxDelay.TabIndex = 5;
            this.uxDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uxAiDeleyLabel
            // 
            this.uxAiDeleyLabel.AutoSize = true;
            this.uxAiDeleyLabel.BackColor = System.Drawing.Color.Transparent;
            this.uxAiDeleyLabel.Location = new System.Drawing.Point(288, 17);
            this.uxAiDeleyLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.uxAiDeleyLabel.Name = "uxAiDeleyLabel";
            this.uxAiDeleyLabel.Size = new System.Drawing.Size(139, 32);
            this.uxAiDeleyLabel.TabIndex = 6;
            this.uxAiDeleyLabel.Text = "AI Speed:";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(904, 703);
            this.Controls.Add(this.uxAiDeleyLabel);
            this.Controls.Add(this.uxDelay);
            this.Controls.Add(this.uxPictureBox);
            this.Controls.Add(this.uxScore);
            this.Controls.Add(this.uxLabelScore);
            this.Controls.Add(this.uxIsAI);
            this.Controls.Add(this.uxMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.uxMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserInterface";
            this.Text = "Classic Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserInterface_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserInterface_PreviewKeyDown);
            this.uxMenuStrip.ResumeLayout(false);
            this.uxMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip uxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem uxFile;
        private System.Windows.Forms.ToolStripMenuItem uxNewGame;
        private System.Windows.Forms.ToolStripMenuItem uxEasy;
        private System.Windows.Forms.ToolStripMenuItem uxNormal;
        private System.Windows.Forms.ToolStripMenuItem uxHard;
        private System.Windows.Forms.CheckBox uxIsAI;
        private System.Windows.Forms.Label uxLabelScore;
        private System.Windows.Forms.Label uxScore;
        private System.Windows.Forms.PictureBox uxPictureBox;
        private System.Windows.Forms.NumericUpDown uxDelay;
        private System.Windows.Forms.Label uxAiDeleyLabel;
    }
}

